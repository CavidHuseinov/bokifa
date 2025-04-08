using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using Oxu.Presentation.Abstraction;

namespace Bokifa.Presentation.Controllers
{
    public class CategoryController:ApiController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
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
            var categoryId = await _service.GetByIdAsync(id);
            return Ok(categoryId);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateCategoryDto dto)
        {
            if(!ModelState.IsValid)  return BadRequest(ModelState);
            var category = await _service.CreateAsync(dto);
            return Ok(category);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateCategoryDto dto)
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
