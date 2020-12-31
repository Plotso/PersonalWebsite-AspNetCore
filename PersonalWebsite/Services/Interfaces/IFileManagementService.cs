namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface IFileManagementService
    {
        Task SaveImageAsync(string imageFolderName, string uniqueFileName, IFormFile image);
    }
}