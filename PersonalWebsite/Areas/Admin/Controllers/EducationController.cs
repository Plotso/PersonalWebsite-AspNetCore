namespace PersonalWebsite.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize]
    public class EducationController : Controller
    {
        private readonly ICVService _cvService;
        private readonly ICVSectionService<EducationCreateInputModel, EducationModifyInputModel> _educationService;
        private readonly ILogger<EducationController> _logger;

        public EducationController(ICVService cvService, ICVSectionService<EducationCreateInputModel, EducationModifyInputModel> educationService, ILogger<EducationController> logger)
        {
            _cvService = cvService;
            _educationService = educationService;
            _logger = logger;
        }
        
        public IActionResult Create()
        {
            var viewModel = new EducationCreateInputModel();
            return View(viewModel);
        }
        
        [HttpPost]
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
        
        public IActionResult Edit(int id)
        {
            var viewModel = _educationService.GetById<EducationModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EducationModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _educationService.EditAsync(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during education record UPDATE operation for educationId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Delete(int id)
        {
            var viewModel = _educationService.GetById<EducationModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(EducationModifyInputModel modifiedModel, string onSubmitAction)
        {
            if (onSubmitAction.IsNullOrEmpty() || onSubmitAction == "Cancel")
            {
                return RedirectToAction("Index", "Home");
            }
            
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _educationService.DeleteAsync(modifiedModel.Id);
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