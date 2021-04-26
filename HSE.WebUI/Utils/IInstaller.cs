using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HSE.WebUI.Utils
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
