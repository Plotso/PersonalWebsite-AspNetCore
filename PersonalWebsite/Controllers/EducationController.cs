namespace PersonalWebsite.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Services;

    public class EducationController : Controller
    {
        private readonly ICVService _cvService;
        private readonly IEducationService _educationService;
        private readonly ILogger<EducationController> _logger;

        public EducationController(ICVService cvService, IEducationService educationService, ILogger<EducationController> logger)
        {
            _cvService = cvService;
            _educationService = educationService;
            _logger = logger;
        }
        
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new EducationCreateInputModel();
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EducationCreateInputModel input)
        {
            var defaultCvId = _cvService.GetId();
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            try
            {
                await _educationService.CreateAsync(input, defaultCvId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured during new education record creation.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}