using Microsoft.AspNetCore.Http;

namespace Oxu.Domain.DTOs.FileUpload
{
    public record CreateFileUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }
    }
}
