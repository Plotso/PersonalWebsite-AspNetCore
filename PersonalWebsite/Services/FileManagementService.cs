namespace PersonalWebsite.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public class FileManagementService : IFileManagementService
    {
        private static readonly string[] ValidImageExtensions = { ".jpeg", ".jpg", ".png", ".gif" };
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileManagementService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        
        /// <summary>
        /// Saves image in a folder if the image is in valid format
        /// </summary>
        /// <param name="imageFolder">For example gallery or profilePictures</param>
        /// <param name="uniqueFileName">The unique name the file should be saved with</param>
        /// <param name="image">The actual image</param>
        /// <returns></returns>
        public async Task SaveImageAsync(string imageFolderName, string uniqueFileName, IFormFile image)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, @$"images\{imageFolderName}");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            
            if (ValidImageExtensions.Any(x => uniqueFileName.EndsWith(x)))
            {
                await using var fileStream = new FileStream(filePath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
            else
            {
                throw new InvalidOperationException("Image is not in valid format - ending with jpeg/jpg/png/gif");
            }
        }
        
        public void DeleteGalleryImage(string imageName)
        {
            var galleryFolder = Path.Combine(_webHostEnvironment.WebRootPath, @"images\gallery");
            var filePath = Path.Combine(galleryFolder, imageName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new InvalidOperationException($@"Image not found gallery\{imageName}");
            }
        }
    }
}