﻿
using Bokifa.Domain.DTOs.Promocode;

namespace Bokifa.Presentation.Controllers
{
    public class PromcodeController:ApiController
    {
        private readonly IPromocodeService _service;
        public PromcodeController(IPromocodeService promocodeService)
        {
            _service = promocodeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var promocodes = await _service.GetAllAsync();
            return Ok(promocodes);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var promocode = await _service.GetByIdAsync(id);
            return Ok(promocode);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreatePromocodeDto dto)
        {
            var promocode = await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePromocodeDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromForm] Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
