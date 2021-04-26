using System.Threading.Tasks;
using HSE.Domain.Entities;

namespace HSE.DAL.Repositories.Abstract
{
    public interface IRecaptchaRepository:IBaseRepository<GoogleRespond>
    {
        Task<GoogleRespond> Verification(string token, string action = "");
    }
}
