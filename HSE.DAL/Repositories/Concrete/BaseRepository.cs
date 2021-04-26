using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class,new()
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(Microsoft.EntityFrameworkCore.DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            var list = await _dbSet.ToListAsync();
            return list.AsQueryable();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
