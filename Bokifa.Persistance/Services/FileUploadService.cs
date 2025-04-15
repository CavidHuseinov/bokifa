using Bookifa.Application.Extensions;
using Bookifa.Domain.DTOs.FileUpload;
using Microsoft.AspNetCore.Hosting;

namespace Bookifa.Persistance.Services
{
    public class FileUploadService:IFileUploadService
    {
        private readonly IWebHostEnvironment _env;
        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<ImageUploadDto> UploadFileAsync(CreateImageUploadDto fileUploadDto)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
            {
                throw new ArgumentException("File not found");
            }

            if (string.IsNullOrWhiteSpace(fileUploadDto.FolderName))
            {
                throw new ArgumentException("Folder not found");
            }
            string imgUrl = fileUploadDto.File.Upload(_env.WebRootPath, fileUploadDto.FolderName);

            return new ImageUploadDto
            {
                ImgUrl = imgUrl
            };
        }

        public async Task<FileUploadDto> UploadFileAsync(CreateFileUploadDto fileUploadDto)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
            {
                throw new ArgumentException("File not found");
            }

            if (string.IsNullOrWhiteSpace(fileUploadDto.FolderName))
            {
                throw new ArgumentException("Folder not found");
            }
            string fileUrl = fileUploadDto.File.Upload(_env.WebRootPath, fileUploadDto.FolderName);

            return new FileUploadDto
            {
                FileUrl = fileUrl
            };
        }

        public async Task<VideoUploadDto> UploadFileAsync(CreateVideoUploadDto fileUploadDto)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
            {
                throw new ArgumentException("File not found");
            }

            if (string.IsNullOrWhiteSpace(fileUploadDto.FolderName))
            {
                throw new ArgumentException("Folder not found");
            }
            string videoUrl = fileUploadDto.File.Upload(_env.WebRootPath, fileUploadDto.FolderName);

            return new VideoUploadDto
            {
                VideoUrl = videoUrl
            };
        }
    }
}
