using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HSE.Business.DTOs;
using HSE.Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSE.WebUI.Controllers
{
    [Route("[controller]")]
    public class CameraController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IErrorLogsService _errorLogsService;
        public CameraController(IWebHostEnvironment webHostEnvironment, IUserService userService, IEmployeeService employeeService,IErrorLogsService errorLogsService)
        {
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
            _employeeService = employeeService;
            _errorLogsService = errorLogsService;
        }

        [HttpPost("Capture")]
        public async Task<IActionResult> Capture(int employeeUserId, int instructionFormId)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                if (file.Length <= 0) continue;
                // Getting Filename  
                var fileName = file.FileName;
                // Unique filename "Guid"  
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                // Getting Extension  
                var fileExtension = Path.GetExtension(fileName);
                // Concating filename + fileExtension (unique filename)  
                var newFileName = string.Concat(myUniqueFileName, fileExtension);
                //  Generating Path to store photo   
                var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";

                if (!string.IsNullOrEmpty(filepath))
                {
                    // Storing Image in Folder      
                    await StoreInFolder(file, employeeUserId, instructionFormId);
                }
            }
            return Json(true);
        }

        /// <summary>  
        /// Saving captured image into Folder.  
        /// </summary>  
        /// <param name="file"></param>
        /// <param name="employeeUserId"></param>
        /// <param name="instructionFormId"></param>
        private async Task StoreInFolder(IFormFile file, int employeeUserId, int instructionFormId)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var user = await _userService.GetUserInfoByUserId(employeeUserId);
                var uploads = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", DateTime.Now.Year.ToString());
                var filePath = Path.Combine(uploads, instructionFormId + user.Fincode + ".jpg");
                HelperMethods.HelperMethods.IfExistDeletePhoto(filePath);
                await using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
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
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
            }
        }

        [HttpGet("IsThePhotoExist")]
        public async Task<IActionResult> IsThePhotoExist(int employeeUserId, int instructionFormId)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var user = await _userService.GetUserInfoByUserId(employeeUserId);
                var fileName = instructionFormId + user.Fincode + ".jpg";

                if (!string.IsNullOrEmpty(fileName))
                {
                    var folderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", DateTime.Now.Year.ToString());
                    var filePath = Path.Combine(folderPath, fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.Net.WebClient net = new System.Net.WebClient();
                        byte[] data = net.DownloadData(filePath);
                        MemoryStream content = new MemoryStream(data);
                        string contentType = "APPLICATION/octet-stream";
                        return File(content, contentType, fileName);
                    }
                    return BadRequest("Şəkil mövcud deyil");
                }
                return BadRequest("Şəklin adı boşdur");
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
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return BadRequest();
            }
        }

        [HttpGet("GetEmployeePhotoByFincode")]
        public async Task<IActionResult> GetEmployeePhotoByFincode(int employeeUserId)
        {
            int instructorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty);
            try
            {
                var user = await _userService.GetUserInfoByUserId(employeeUserId);
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
                    UserId = instructorUserId,
                    ErrorLineNumber = errorLineNumber,
                    CreateDate = DateTime.Now
                };
                await _errorLogsService.AddErrorLog(errorLogDto);
                return BadRequest();
            }
        }
    }
}

