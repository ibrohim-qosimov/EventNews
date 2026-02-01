using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace EventNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
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
            var result = await _newsService.GetNewByIdAdmin(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllNews()
        {
            var results = await _newsService.GetAllNewsAdmin();
            return Ok(results);
        }
    }
}
