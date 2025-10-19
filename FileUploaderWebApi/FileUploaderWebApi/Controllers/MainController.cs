using FileUploaderWebApi.PublicClasses;
using Microsoft.AspNetCore.Mvc;

namespace FileUploaderWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            UploadStatus status = new();
            status = new UploadHandler().UploadFile(file);

            if(!status.IsSuccess)
            {
                return BadRequest(status.Message);
            }

            return Ok(status.fileName);
        }
    }
}
