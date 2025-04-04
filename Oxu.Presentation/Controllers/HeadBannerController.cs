using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.HeadBanner;
using Microsoft.AspNetCore.Mvc;
using Oxu.Presentation.Abstraction;

namespace Bokifa.Presentation.Controllers
{
    public class HeadBannerController:ApiController
    {
        private readonly IHeadBannerService _service;
        public HeadBannerController(IHeadBannerService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateHeadBannerDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateHeadBannerDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
