﻿using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Presentation.Controllers
{
    public sealed class BookController:ApiController
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateBookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateBookDto dto)
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
