using AutoMapper;
using HSE.Business.MapConfig;
using HSE.Business.Services.Abstract;
using HSE.Business.Services.Concrete;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.DAL.Repositories.Concrete;
using HSE.DAL.Settings;
using HSE.WebUI.ServiceFacade;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HSE.WebUI.Utils
{
    public class ServiceConfig:IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HseDbContext>(option => {
                option.UseSqlServer(AppSettings.ConnectionString);
            });
            services.AddMvcCore().AddRazorViewEngine();
            services.AddControllersWithViews();
            services.AddAuthorization();
            services.Configure<RecaptchaSettings>(configuration.GetSection("GoogleReCaptchaSetting"));
            DependencyInjectionRepositories(services);
            DependencyInjectionServices(services);
            DependencyInjectionFacades(services);
            DependencyInjectionMappers(services);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Account/Login");
                        options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                        options.LogoutPath = new PathString("/Account/Logout");
                        options.SlidingExpiration = true;
                        options.ExpireTimeSpan = System.TimeSpan.FromMinutes(33);
                    }
                );
        }

        private void DependencyInjectionRepositories(IServiceCollection service)
        {
            service.AddScoped<IRecaptchaRepository, RecaptchaRepository>();
            service.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
            service.AddScoped<ILoginLogRepository, LoginLogRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IInstructionTypeRepository, InstructionTypeRepository>();
            service.AddScoped<IInstructionFormRepository, InstructionFormRepository>();
            service.AddScoped<IEmployeeFormRepository, EmployeeFormRepository>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        private void DependencyInjectionFacades(IServiceCollection service)
        {
            service.AddScoped<AccountServiceFacade>();
            service.AddScoped<FormServiceFacade>();
        }

        private void DependencyInjectionServices(IServiceCollection service)
        {
            service.AddScoped<IRecaptchaService, RecaptchaService>();
            service.AddScoped<IAuthenticateService, AuthenticateService>();
            service.AddScoped<ILoginLogService, LoginLogService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IInstructionTypeService, InstructionTypeService>();
            service.AddScoped<IInstructionFormService, InstructionFormService>();
            service.AddScoped<IEmployeeFormService, EmployeeFormService>();
            service.AddScoped<IEmployeeService, EmployeeService>();
        }

        private void DependencyInjectionMappers(IServiceCollection service)
        {
            var mapConfig = new MapperConfiguration(config => { config.AddProfile(new MapperConfig()); });
            IMapper mapper = mapConfig.CreateMapper();
            service.AddSingleton(mapper);
        }
    }
}
