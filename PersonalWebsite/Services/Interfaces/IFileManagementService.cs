namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface IFileManagementService
    {
        void DeleteGalleryImage(string imageName);
        
        Task SaveImageAsync(string imageFolderName, string uniqueFileName, IFormFile image);
    }
}