namespace PersonalWebsite.Models.InputModels
{
    using Microsoft.AspNetCore.Http;

    public class GalleryInputModel
    {
        public IFormFile Image { get; set; }
    }
}