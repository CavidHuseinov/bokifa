using Microsoft.AspNetCore.Http;

namespace Bookifa.Application.Extensions
{
    public static class FileExtension
    {

        public static string Upload(this IFormFile file, string rootpath, string folderName)
        {
            string filename = file.FileName;

            if (filename.Length > 64)
            {
                filename = filename.Substring(filename.Length - 64, 64);
            }

            filename = Guid.NewGuid() + filename;
            string path = Path.Combine(rootpath, "Uploads", folderName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/Uploads/{folderName}/{filename}";
        }

        public static bool DeleteFile(string rootPath, string fileUrl)
        {
            string fullPath = Path.Combine(rootPath, fileUrl.TrimStart('/'));

            if (!File.Exists(fullPath))
            {
                return false;
            }

            File.Delete(fullPath);
            return true;
        }

    }
}
