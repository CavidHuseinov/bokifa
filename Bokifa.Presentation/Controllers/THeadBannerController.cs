using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.THeadBanner;
using Microsoft.AspNetCore.Mvc;
using Bookifa.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Presentation.Controllers
{
    public sealed class THeadBannerController:ApiController
    {
        private readonly ITHeadBannerService _service;

        public THeadBannerController(ITHeadBannerService service)
        {
            _service = service;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateTHeadBannerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateTHeadBannerDto dto)
        {
           if (!ModelState.IsValid) return BadRequest(ModelState);
           await _service.UpdateAsync(dto);
           return NoContent();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
