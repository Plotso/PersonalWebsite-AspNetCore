namespace PersonalWebsite.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Services.Interfaces;

    public class EducationController : Controller
    {
        private readonly ICVService _cvService;
        private readonly ICVModelService<EducationCreateInputModel, EducationModifyInputModel> _educationService;
        private readonly ILogger<EducationController> _logger;

        public EducationController(ICVService cvService, ICVModelService<EducationCreateInputModel, EducationModifyInputModel> educationService, ILogger<EducationController> logger)
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
        [ValidateAntiForgeryToken]
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
        
        [Authorize]
        public IActionResult Edit(int id)
        {
            var viewModel = _educationService.GetById<EducationModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EducationModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _educationService.Edit(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during education record UPDATE operation for educationId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        [Authorize]
        public IActionResult Delete(int id)
        {
            var viewModel = _educationService.GetById<EducationModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(EducationModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _educationService.Delete(modifiedModel.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during education record DELETE operation for educationId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}