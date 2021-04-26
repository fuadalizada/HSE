using System.Linq;
using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IInstructionTypeService:IBaseService<InstructionTypeDto>
    {
        Task<IQueryable<InstructionTypeDto>> GetActiveTypes();
    }
}
