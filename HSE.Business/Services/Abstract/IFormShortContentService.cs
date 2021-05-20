using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IFormShortContentService:IBaseService<FormShortContentDto>
    {
        Task<IQueryable<FormShortContentDto>> GetShortContentNames();
    }
}
