namespace PersonalWebsite.Controllers
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.InputModels;
    using Models.ViewModels;
    using Services;
    using Services.Interfaces;

    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        
        public IActionResult All()
        {
            var viewModel = new GalleryViewModel
            {
                ImagesNames = _galleryService.GetAllImages(),
                ImageUpload = new GalleryInputModel()
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(GalleryViewModel viewModel)
        {
            if (ModelState.IsValid && viewModel.ImageUpload != null)
            {
                await _galleryService.UploadImage(viewModel.ImageUpload);
            }

            return RedirectToAction(nameof(All));
        }
    }
}