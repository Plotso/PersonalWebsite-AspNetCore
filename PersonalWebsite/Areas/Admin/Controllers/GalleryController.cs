namespace PersonalWebsite.Areas.Admin.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Models.ViewModels;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly ILogger<GalleryController> _logger;

        public GalleryController(IGalleryService galleryService, ILogger<GalleryController> logger)
        {
            _galleryService = galleryService;
            _logger = logger;
        }
        
        public IActionResult List()
        {
            var viewModel = new GalleryViewModel
            {
                ImagesNames = _galleryService.GetAllImages(),
                ImageUpload = new GalleryInputModel()
            };
            return View(viewModel);
        }

        public IActionResult Delete(string imageName)
        {
            try
            {
                _galleryService.DeleteImage(imageName);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured during new skill record creation.");
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction(nameof(List));
        }
    }
}