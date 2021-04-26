using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.DAL.ViewModels;

namespace HSE.Business.Services.Abstract
{
    public interface IAuthenticateService:IBaseService<AuthenticateDto>
    {
        Task<AuthenticateDto> Authenticate(LoginViewModel model, string remoteIpAddress);
    }
}
