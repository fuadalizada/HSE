using System.Linq;
using System.Threading.Tasks;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
    }
}
