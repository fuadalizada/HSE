using System.Threading.Tasks;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IAuthenticateRepository : IBaseRepository<Authenticate>
    {
        Task<Authenticate> Authenticate(LoginViewModel model, string remoteIpAddress);
    }
}
