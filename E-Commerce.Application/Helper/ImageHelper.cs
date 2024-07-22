using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce.Application.Helper
{
    public static class ImageHelper
    {

        public static async Task<string> SaveImageAsync(IFormFile imageFile, string rootPath, string folder)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            var uploadsFolder = Path.Combine(rootPath, folder);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);   
            }


            var uniqueFileName = Guid.NewGuid().ToString() + ".jpg"; // Ensuring it's a .jpg file

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return Path.Combine(folder, uniqueFileName).Replace("\\", "/");
        }


        public static string GetImageFilePath(string relativePath, string webRootPath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            var absolutePath = Path.Combine(webRootPath, relativePath.TrimStart('/').Replace("/", "\\"));

            if (!File.Exists(absolutePath))
            {
                throw new FileNotFoundException($"Image file not found at path: {absolutePath}");
            }

            return absolutePath;
        }

        public static bool DeleteImage(string relativePath, string webRootPath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            var absolutePath = Path.Combine(webRootPath, relativePath.TrimStart('/').Replace("/", "\\"));

            if (File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
                return true;
            }

            return false;
        }

    }
}
