using EventNews.API.Abstractions;
using EventNews.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _regionService.GetAllRegions();
            return Ok(results);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _regionService.GetRegionById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRegionDTO dto)
        {
            var result = await _regionService.AddRegion(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRegionDTO dto)
        {
            var result = await _regionService.UpdateRegion(dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var success = _regionService.DeleteRegion(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
