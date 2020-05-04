using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Festival.Web.Helper
{
    public static class ImageDelete
    {
        public static void DeleteImage(IWebHostEnvironment webhost, string folder, string fileName)
        {
            string fullPath = Path.Combine(webhost.WebRootPath, "images", folder, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}
