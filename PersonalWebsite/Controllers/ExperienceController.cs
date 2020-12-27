namespace PersonalWebsite.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Models.ViewModels;
    using Services;

    public class ExperienceController : Controller
    {
        private readonly ICVService _cvService;
        private readonly IExperienceService _experienceService;
        private readonly ILogger<ExperienceController> _logger;

        public ExperienceController(ICVService cvService, IExperienceService experienceService, ILogger<ExperienceController> logger)
        {
            _cvService = cvService;
            _experienceService = experienceService;
            _logger = logger;
        }
        
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new ExperienceCreateInputModel();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ExperienceCreateInputModel input)
        {
            var defaultCvId = _cvService.GetId();
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            try
            {
                await _experienceService.CreateAsync(input, defaultCvId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured during new experience record creation.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}