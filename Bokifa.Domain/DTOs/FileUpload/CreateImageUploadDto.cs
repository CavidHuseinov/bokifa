using Microsoft.AspNetCore.Http;

namespace Bookifa.Domain.DTOs.FileUpload
{
    public record CreateImageUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }
    }
}
