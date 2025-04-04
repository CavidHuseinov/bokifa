using Oxu.Domain.DTOs.FileUpload;

namespace Oxu.Application.IServices
{
    public interface IFileUploadService
    {
        Task<ImageUploadDto> UploadFileAsync(CreateImageUploadDto fileUploadDto);
        Task<FileUploadDto> UploadFileAsync(CreateFileUploadDto fileUploadDto);
        Task<VideoUploadDto> UploadFileAsync(CreateVideoUploadDto fileUploadDto);

    }
}
