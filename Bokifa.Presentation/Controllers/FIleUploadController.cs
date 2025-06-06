﻿using Bookifa.Domain.DTOs.FileUpload;

namespace Bookifa.Presentation.Controllers
{
    public sealed class FIleUploadController:ApiController
    {
        private readonly IFileUploadService _fileUploadService;
        public FIleUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }
        [HttpPost("image")]
        public async Task<IActionResult> UploadFileAsync([FromForm]CreateImageUploadDto fileUploadDto)
        {
            ImageUploadDto result = await _fileUploadService.UploadFileAsync(fileUploadDto);
            return Ok(result);
        }
        [HttpPost("file")]
        public async Task<IActionResult> UploadFileAsync([FromForm] CreateFileUploadDto fileUploadDto)
        {
            FileUploadDto result = await _fileUploadService.UploadFileAsync(fileUploadDto);
            return Ok(result);
        }
        [HttpPost("video")]
        public async Task<IActionResult> UploadFileAsync([FromForm] CreateVideoUploadDto fileUploadDto)
        {
            VideoUploadDto result = await _fileUploadService.UploadFileAsync(fileUploadDto);
            return Ok(result);
        }
    }
}
