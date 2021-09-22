using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using HSE.WebUI.ServiceFacade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
namespace HSE.WebUI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FormServiceFacade _formServiceFacade;
        private readonly IErrorLogsService _errorLogsService;
        public FileController(IUserService userService, IWebHostEnvironment webHostEnvironment, IEmployeeService employeeService,FormServiceFacade formServiceFacade, IErrorLogsService errorLogsService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _employeeService = employeeService;
            _formServiceFacade = formServiceFacade;
            _errorLogsService = errorLogsService;
        }

        [HttpGet("GetUserPhoto")]
        public async Task<IActionResult> GetUserPhoto()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var user = await _userService.GetUserInfoByUserId(userId);
                byte[] fileContent = await _employeeService.GetUserPhotoByFincode(user.Fincode);
                string contentType;
                if (fileContent == null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", "employeeImages", $"{ user.Fincode.ToUpper()}.JPG");

                    if (!System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", $"{user.Gender.ToString().ToLower()}.png");
                    }
                    System.Net.WebClient net = new System.Net.WebClient();

                    byte[] data = net.DownloadData(filePath);
                    MemoryStream content = new MemoryStream(data);
                    contentType = "APPLICATION/octet-stream";

                    return File(content, contentType, Path.GetFileName(filePath));
                }

                MemoryStream stream = new MemoryStream(fileContent);
                contentType = "APPLICATION/octet-stream";
                return File(stream, contentType, "userPhoto.jpg");
            }
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = null,
                    UserId = userId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return BadRequest();
            }
        }

        [HttpGet("GenerateQrCode")]
        public async Task<IActionResult> GenerateQrCode(int employeeUserId, int instructionFormId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var user = await _userService.GetUserInfoByUserId(employeeUserId);
                var employeeFullName = $"{user.Firstname} {user.Lastname}";
                var photoDate = await _formServiceFacade.GetPhotoDate(instructionFormId, employeeUserId);
                string text = "Təlimat formunun nömrəsi: " + instructionFormId + "\n" + "Təlimatlandırılan şəxsin adı,soyadı: " + employeeFullName + "\n"
                              + "Şəklin çəkilmə tarixi: " + photoDate;

                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new QRCode(qrCodeData);
                var qrCodeAsBitmap = qrCode.GetGraphic(2, Color.Black, Color.White, true);
                var path = Path.Combine(_webHostEnvironment.ContentRootPath, $"Files/qrcode{DateTime.Now.Year}/{instructionFormId}{user.Fincode}.jpeg");
                qrCodeAsBitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                var net = new System.Net.WebClient();
                byte[] data = net.DownloadData(path);
                var content = new MemoryStream(data);
                var contentType = "APPLICATION/octet-stream";

                return File(content, contentType, Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                var errorLineNumber = HelperMethods.HelperMethods.GetLineNumber(ex);

                ErrorLogDto errorLogDto = new ErrorLogDto
                {
                    ActionName = ControllerContext.ActionDescriptor.ControllerName + "/" +
                                 ControllerContext.ActionDescriptor.ActionName,
                    ErrorMessage = ex.InnerException == null ? "Xəta baş verdi." : ex.InnerException.Message,
                    InstructionFormId = instructionFormId,
                    UserId = userId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return BadRequest();
            }            
        }
    }
}
