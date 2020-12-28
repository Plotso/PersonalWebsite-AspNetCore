namespace PersonalWebsite.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface IGalleryService
    {
        IEnumerable<string> GetAllImages();

        Task UploadImage(GalleryInputModel imageInput);
    }
}