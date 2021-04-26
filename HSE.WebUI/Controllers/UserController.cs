using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;

namespace HSE.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoto()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            var user = await _userService.GetUserInfoByUserId(userId);

            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", "employeeImages", $"{ user.Fincode.ToUpper()}.JPG");

            if (!System.IO.File.Exists(filePath))
            {
                filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", $"{user.Gender.ToString().ToLower()}.png");
            }

            System.Net.WebClient net = new System.Net.WebClient();

            byte[] data = net.DownloadData(filePath);
            MemoryStream content = new System.IO.MemoryStream(data);
            string contentType = "APPLICATION/octet-stream";

            return File(content, contentType, Path.GetFileName(filePath));
        }
    }
}
