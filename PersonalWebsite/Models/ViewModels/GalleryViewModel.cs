namespace PersonalWebsite.Models.ViewModels
{
    using System.Collections.Generic;
    using InputModels;

    public class GalleryViewModel
    {
        public IEnumerable<string> ImagesNames { get; set; }
        
        public GalleryInputModel ImageUpload { get; set; }
    }
}