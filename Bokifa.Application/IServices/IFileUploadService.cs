using Bookifa.Domain.DTOs.FileUpload;

namespace Bookifa.Application.IServices
{
    public interface IFileUploadService
    {
        Task<ImageUploadDto> UploadFileAsync(CreateImageUploadDto fileUploadDto);
        Task<FileUploadDto> UploadFileAsync(CreateFileUploadDto fileUploadDto);
        Task<VideoUploadDto> UploadFileAsync(CreateVideoUploadDto fileUploadDto);

    }
}
