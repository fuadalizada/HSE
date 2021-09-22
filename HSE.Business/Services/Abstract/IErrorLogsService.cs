using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IErrorLogsService:IBaseService<ErrorLogDto>
    {
        Task AddErrorLog(ErrorLogDto dto);
    }
}
