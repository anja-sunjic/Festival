using Microsoft.AspNetCore.Http;
using System.IO;

namespace FestivalWebApplication.Helper
{
    public class ImageUpload
    {
        public static void UploadImageToFolder(IFormFile image, string path)
        {
            var fileStream = new FileStream(path, FileMode.Create);
            image.CopyTo(fileStream);
            fileStream.Dispose();
        }
    }
}
