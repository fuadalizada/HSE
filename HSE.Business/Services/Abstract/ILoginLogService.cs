using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface ILoginLogService : IBaseService<LoginLogDto>
    {
        Task<LoginLogDto> AddLog(LoginLogDto dto);
    }
}
