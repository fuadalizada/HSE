using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IUserRoleService:IBaseService<UserRoleDto>
    {
        Task<string> GetUserRoleByUserId(int userId);
    }
}
