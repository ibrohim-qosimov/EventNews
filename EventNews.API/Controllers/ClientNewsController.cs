using EventNews.API.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientNewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public ClientNewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetNewsById(long id)
        {
            var result = await _newsService.GetNewsById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var results = await _newsService.GetAllNews();
            return Ok(results);
        }
    }
}
