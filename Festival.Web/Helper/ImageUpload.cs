using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Festival.Web.Helper
{
    public static class ImageUpload
    {
        public static string UploadImage(IFormFile image, IWebHostEnvironment webhost, string modelName)
        {

            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(webhost.WebRootPath, "images", modelName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
