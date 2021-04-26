using System.Linq;
using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IInstructionTypeRepository:IBaseRepository<InstructionType>
    {
        Task<IQueryable<InstructionType>> GetActiveTypes();
    }
}
