using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IRecaptchaService:IBaseService<GoogleRespondDto>
    {
        Task<GoogleRespondDto> Verification(string token, string action = "");
    }
}
