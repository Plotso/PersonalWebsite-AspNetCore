namespace PersonalWebsite.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Services;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class SkillsController : Controller
    {
        private readonly ICVService _cvService;
        private readonly ICVSectionService<SkillCreateInputModel, SkillModifyInputModel> _skillsService;
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ICVService cvService, ICVSectionService<SkillCreateInputModel, SkillModifyInputModel> skillsService, ILogger<SkillsController> logger)
        {
            _cvService = cvService;
            _skillsService = skillsService;
            _logger = logger;
        }
        
        public IActionResult Create()
        {
            var viewModel = new SkillCreateInputModel();
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillCreateInputModel input)
        {
            var defaultCvId = _cvService.GetId();
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            try
            {
                await _skillsService.CreateAsync(input, defaultCvId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured during new skill record creation.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Edit(int id)
        {
            var viewModel = _skillsService.GetById<SkillModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _skillsService.EditAsync(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during skill record UPDATE operation for skillId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Delete(int id)
        {
            var viewModel = _skillsService.GetById<SkillModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SkillModifyInputModel modifiedModel, string onSubmitAction)
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
                await _skillsService.DeleteAsync(modifiedModel.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during skill record DELETE operation for skillId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}