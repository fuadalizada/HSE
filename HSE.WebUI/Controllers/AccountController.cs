using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HSE.Business.Services.Abstract;
using HSE.DAL.DbContext;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;
using HSE.WebUI.ServiceFacade;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace HSE.WebUI.Controllers 
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly HseDbContext _context;
        private readonly IRecaptchaService _recaptchaService;
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly AccountServiceFacade _accountServiceFacade;

        public AccountController(IRecaptchaService recaptchaService, IMapper mapper, HseDbContext context, IAuthenticateService authenticateService, IUserRoleService userRoleService,
            IUserService userService, AccountServiceFacade accountServiceFacade)
        {
            _context = context;
            _recaptchaService = recaptchaService;
            _authenticateService = authenticateService;
            _mapper = mapper;
            _userService = userService;
            _userRoleService = userRoleService;
            _accountServiceFacade = accountServiceFacade;
        }

        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        {
            if (!Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                return new RedirectResult(Url.Action("AccessDenied", "Account", new { refererUrl = "/Account/Login?ReturnUrl=" + returnUrl + "" }));
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            System.Net.IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            string browserInfo = Request.Headers["User-Agent"].ToString();
            var googleRespond = await _recaptchaService.Verification(model.Token, "login");

            if (!googleRespond.Success && googleRespond.Score <= 0.5 && !Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                await _accountServiceFacade.AddLoginLog(model, browserInfo, remoteIpAddress, true);
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                await _accountServiceFacade.AddLoginLog(model, browserInfo, remoteIpAddress, false);
                return View(model);
            }


            var result = await _authenticateService.Authenticate(model, remoteIpAddress.ToString());
            if (result !=null)
            {
                var userId = await _userService.GetUserIdByFincode(result.Fincode);
                var role = await _userRoleService.GetUserRoleByUserId(userId);
                result.Id = userId;
                result.RoleName = role;
                var user = _mapper.Map<Authenticate>(result);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "İstifadəçi adı və ya şifrə yanlışdır.";
                    await _accountServiceFacade.AddLoginLog(model, browserInfo, remoteIpAddress, false);
                    return View(model);
                }

                await _accountServiceFacade.AddLoginLog(model, browserInfo, remoteIpAddress, true);
                return await SignInUser(user, returnUrl);
            }

            ViewBag.ErrorMessage = "İstifadəçi adı və ya şifrə yanlışdır.";
            await _accountServiceFacade.AddLoginLog(model, browserInfo, remoteIpAddress, false);
            return View(model);
        }

        private async Task<IActionResult> SignInUser(Authenticate user, string returnUrl)
        {
            await TakeInfoWithClaims(user);
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home");
            }

            return new RedirectResult(returnUrl + "#fromLogin");
        }

        private async Task TakeInfoWithClaims(Authenticate user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Fincode));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FatherName));
            identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.UserOrgId));
            identity.AddClaim(new Claim(ClaimTypes.Actor, user.Position));
            identity.AddClaim(new Claim(ClaimTypes.WindowsSubAuthority, string.Empty));
            identity.AddClaim(new Claim(ClaimTypes.IsPersistent, string.Empty));
            identity.AddClaim(new Claim(ClaimTypes.Dns, string.Empty));
            identity.AddClaim(new Claim("IsManager", user.IsManager.ToString()));
            identity.AddClaim(new Claim("TourDate", user.TourDate + string.Empty));
            identity.AddClaim(new Claim("LayoutOptions", user.LayoutOptions ?? string.Empty));
            foreach (string role in user.RoleName.Split(","))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }


        
        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied(string refererUrl = null)
        {
            System.Net.IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            string browserInfo = Request.Headers["User-Agent"].ToString();
            int? userId = null;
            if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value != null && !string.IsNullOrEmpty(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value))
            {
                userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            }

            if (remoteIpAddress != null)
                _context.Set<AccessDeniedLog>().Add(new AccessDeniedLog()
                {
                    UserId = userId,
                    RemoteIpAddress = remoteIpAddress.ToString(),
                    BrowserInfo = browserInfo,
                    RefererUrl = refererUrl
                });
            _context.SaveChanges();
            return Json("Access denied...");
        }

      
        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
