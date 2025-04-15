using Bookifa.Domain.DTOs.FileUpload;

namespace Bookifa.Application.Validators.FileUpload
{
    public class CreateFileUploadValidator : AbstractValidator<CreateFileUploadDto>
    {
        public CreateFileUploadValidator()
        {
            RuleFor(x => x.File)
                 .NotNull().WithMessage("The File must be uploaded.")
                 .Must(x => x.Length <= 5 * 1024 * 1024).WithMessage("The maximum allowed file size is 5MB. Please upload a valid file.")
                 .Must(x => IsValidImage(x)).WithMessage("Invalid file format. Supported formats: .pdf, .doc, .docx");
        }

        private bool IsValidImage(IFormFile file)
        {
            if (file == null) return false;

            var validMimeTypes = new List<string>
            {
            "application/pdf",
            "application/msword",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            };

            return validMimeTypes.Contains(file.ContentType.ToLower());
        }

    }
}
