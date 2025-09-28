using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNews([FromBody] CreateNews dto)
        {
            var result = await _newsService.AddNews(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNews([FromBody] UpdateNews dto)
        {
            var result = await _newsService.UpdateNews(dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteNews(long id)
        {
            var success = _newsService.DeleteNews(id);
            if (!success) return NotFound();
            return NoContent();
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
