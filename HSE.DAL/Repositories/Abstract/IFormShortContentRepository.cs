using System.Linq;
using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IFormShortContentRepository:IBaseRepository<FormShortContent>
    {
        Task<IQueryable<FormShortContent>> GetShortContentNames();
    }
}
