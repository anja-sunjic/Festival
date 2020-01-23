using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;

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
