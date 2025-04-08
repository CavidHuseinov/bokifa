using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.TCategory;
using Microsoft.AspNetCore.Mvc;
using Bookifa.Presentation.Abstraction;

namespace Bokifa.Presentation.Controllers
{
    public class TCategoryController:ApiController
    {
        private readonly ITCategoryService _service;

        public TCategoryController(ITCategoryService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var tTCategoryId = await _service.GetByIdAsync(id);
            return Ok(tTCategoryId);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTCategoryDto dto)
        {
            if(!ModelState.IsValid)  return BadRequest(ModelState);
            var tTCategory = await _service.CreateAsync(dto);
            return Ok(tTCategory);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateTCategoryDto dto)
        {
            if(!ModelState.IsValid)  return BadRequest(ModelState);
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
