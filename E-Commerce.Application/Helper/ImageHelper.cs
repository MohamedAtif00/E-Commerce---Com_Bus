using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace E_Commerce.Application.Helper
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImageAsync(IFormFile imageFile, string rootPath, string folder,string fileName = null)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Image file cannot be null or empty", nameof(imageFile));
            }

            var uploadsFolder = Path.Combine(rootPath, folder);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileExtension = Path.GetExtension(imageFile.FileName);


            string? uniqueFileName = fileName ?? Guid.NewGuid().ToString() + fileExtension;


            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                // Log exception (if logging is configured)
                // _logger.LogError(ex, "Error occurred while saving image file.");
                throw;
            }

            return Path.Combine(folder, uniqueFileName).Replace("\\", "/");
        }

        public static string GetImageFilePath(string relativePath, string webRootPath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            try
            {
                var absolutePath = Path.Combine(webRootPath, relativePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

                if (!File.Exists(absolutePath))
                {
                    throw new FileNotFoundException($"Image file not found at path: {absolutePath}");
                }

                return absolutePath;
            }
            catch (Exception ex)
            {
                // Log exception (if logging is configured)
                // _logger.LogError(ex, "Error occurred while getting image file path.");
                throw;
            }
        }

        public static bool DeleteImage(string relativePath, string webRootPath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            var absolutePath = Path.Combine(webRootPath, relativePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

            try
            {
                if (File.Exists(absolutePath))
                {
                    File.Delete(absolutePath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log exception (if logging is configured)
                // _logger.LogError(ex, "Error occurred while deleting image file.");
                throw;
            }
        }
    }
}
