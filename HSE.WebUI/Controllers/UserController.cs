using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace HSE.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public UserController()
        {
            
        }
    }
}
