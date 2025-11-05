using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _contextAccessor;

        public FilesController(IFileService fileService, IHttpContextAccessor contextAccessor)
        {
            _fileService = fileService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var fileId = await _fileService.SaveFileAsync(file);

            var request = _contextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var fileUrl = $"{baseUrl}/uploads/{fileId}{System.IO.Path.GetExtension(file.FileName)}";

            return Ok(new
            {
                FileId = fileId,
                Url = fileUrl
            });
        }
    }
    
}