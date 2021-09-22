using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IErrorLogsRepository:IBaseRepository<ErrorLog>
    {
        Task AddErrorLog(ErrorLog entity);
    }
}
