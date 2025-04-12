using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.TVariant;
using Bookifa.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Bokifa.Presentation.Controllers
{
    public class TVariantController : ApiController
    {
        private readonly ITVariantService _service;
        public TVariantController(ITVariantService variantService)
        {
            _service = variantService;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var variants = await _service.GetAllAsync();
            return Ok(variants);
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTVariantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateTVariantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}