using Microsoft.AspNetCore.Http;

namespace Bookifa.Domain.DTOs.FileUpload
{
    public record CreateVideoUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }
    }
}
