using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface ILoginLogRepository:IBaseRepository<LoginLog>
    {
        Task<LoginLog> AddLog(LoginLog entity);
    }
}
