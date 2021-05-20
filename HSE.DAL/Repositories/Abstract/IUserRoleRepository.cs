using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IUserRoleRepository:IBaseRepository<UserRole>
    {
        Task<string> GetUserRoleByUserId(int userId);
    }
}
