using System.Linq;
using System.Threading.Tasks;

namespace HSE.Business.Services.Abstract
{
    public interface IBaseService<TDto> where TDto:class,new()
    {
        Task<IQueryable<TDto>> GetAll();
        Task<TDto> Add(TDto dto);
    }
}
