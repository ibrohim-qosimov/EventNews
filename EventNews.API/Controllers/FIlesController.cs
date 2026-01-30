using System.Threading.Tasks;
using EventNews.API.Abstractions;
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
        private readonly INewsImagesService _newsImagesService;
        public FilesController(IFileService fileService, IHttpContextAccessor contextAccessor, INewsImagesService newsImagesService)
        {
            _fileService = fileService;
            _contextAccessor = contextAccessor;
            _newsImagesService = newsImagesService;
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

        [HttpPost("upload-multiple/{newsId}")]
        public async Task<IActionResult> UploadMultipleFiles([FromForm] IFormFileCollection files, long newsId)
        {
            var result = await _newsImagesService.AddImagesToSingleNews(files, newsId);
            
            if (result)
            {
                return Ok(new { Message = "Files uploaded successfully." });
            }
            else
            {
                return StatusCode(500, new { Message = "An error occurred while uploading files." });
            }
        }
    }
}