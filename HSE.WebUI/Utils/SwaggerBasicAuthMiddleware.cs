using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HSE.WebUI.Utils
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public SwaggerBasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Make sure we are hitting the swagger path
            if (context.Request.Path.StartsWithSegments("/hse-swagger"))
            {
                if (!IsLocalRequest(context))
                {
                    // Return unauthorized
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.Redirect("Account/AccessDenied");
                    return;
                }

                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    // Get the encoded username and password
                    var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                    // Decode from Base64 to string
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    // Split username and password
                    var username = decodedUsernamePassword.Split(':', 2)[0];
                    var password = decodedUsernamePassword.Split(':', 2)[1];

                    // Check if login is correct
                    if (IsAuthorized(username, password))
                    {
                        await _next.Invoke(context);
                        return;
                    }
                }

                // Return authentication type (causes browser to show login dialog)
                context.Response.Headers["WWW-Authenticate"] = "Basic";

                // Return unauthorized
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await _next.Invoke(context);
            }


        }

        public bool IsAuthorized(string username, string password)
        {
            // Check that username and password are correct
            return username.Equals("hse-swagger.ady.az", StringComparison.InvariantCultureIgnoreCase)
                    && password.Equals("469a7d547f5fc4424eecb3448c6fa6752f28e3559c8aeed246d74d4ce519b11f");
        }

        public bool IsLocalRequest(HttpContext context)
        {
            //Handle running using the Microsoft.AspNetCore.TestHost and the site being run entirely locally in memory without an actual TCP/IP connection
            return context.Connection.RemoteIpAddress.Equals(context.Connection.LocalIpAddress)
                || context.Connection.RemoteIpAddress.ToString().StartsWith("192.168");
        }
    }
    public static class SwaggerAuthorizeExtensions
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
        }
    }
}
