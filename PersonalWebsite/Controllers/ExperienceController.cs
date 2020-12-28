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
    using Services.Interfaces;

    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly ICVService _cvService;
        private readonly ICVModelService<ExperienceCreateInputModel, ExperienceModifyInputModel> _experienceService;
        private readonly ILogger<ExperienceController> _logger;

        public ExperienceController(ICVService cvService, ICVModelService<ExperienceCreateInputModel, ExperienceModifyInputModel> experienceService, ILogger<ExperienceController> logger)
        {
            _cvService = cvService;
            _experienceService = experienceService;
            _logger = logger;
        }
        
        public IActionResult Create()
        {
            var viewModel = new ExperienceCreateInputModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        
        public IActionResult Edit(int id)
        {
            var viewModel = _experienceService.GetById<ExperienceModifyInputModel>(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExperienceModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _experienceService.Edit(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during experience record UPDATE operation for educationId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Delete(int id)
        {
            var viewModel = _experienceService.GetById<ExperienceModifyInputModel>(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ExperienceModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _experienceService.Delete(modifiedModel.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during experience record DELETE operation for educationId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}