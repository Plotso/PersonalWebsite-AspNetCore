namespace PersonalWebsite.Services
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Models.InputModels;

    public class GalleryService : IGalleryService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileManagementService _fileManagementService;

        public GalleryService(IWebHostEnvironment webHostEnvironment, IFileManagementService fileManagementService)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileManagementService = fileManagementService;
        }
        
        public IEnumerable<string> GetAllImages()
        {
            var path = _webHostEnvironment.WebRootPath;
            var imagesPaths = Directory.GetFiles(@$"{path}\images\gallery");
            var imagesCount = imagesPaths.Length;
            var imagesNames = new string[imagesCount];
            var counter = 0;
            foreach (var imagePath in imagesPaths)
            {
                var lastSlashIndex = imagePath.LastIndexOf('\\');
                var imageName = imagePath.Substring(lastSlashIndex + 1);
                imagesNames[counter++] = imageName;
            }
            return imagesNames;
        }

        public async Task UploadImageAsync(GalleryInputModel imageInput)
        {
            var fileName = imageInput.Image.FileName;
            var uniqueFileName = Guid.NewGuid() + fileName;

            await _fileManagementService.SaveImageAsync("gallery", uniqueFileName, imageInput.Image);
        }

        public void DeleteImage(string imageName)
        {
            _fileManagementService.DeleteGalleryImage(imageName);
        }
    }
}