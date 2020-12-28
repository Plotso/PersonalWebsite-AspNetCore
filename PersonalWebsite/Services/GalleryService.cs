namespace PersonalWebsite.Services
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore.Internal;
    using Models.InputModels;

    public class GalleryService : IGalleryService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GalleryService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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

        public async Task UploadImage(GalleryInputModel imageInput)
        {
            var fileName = imageInput.Image.FileName;
            var uniqueFileName = Guid.NewGuid() + fileName; 
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, @"images\gallery");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            var expectedFileExt = new[] { ".jpeg", ".jpg", ".png", ".gif" };
            if (expectedFileExt.Any(x => fileName.EndsWith(x)))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageInput.Image.CopyToAsync(fileStream);
                }
            }
        }
    }
}