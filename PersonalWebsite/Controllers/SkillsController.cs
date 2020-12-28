namespace PersonalWebsite.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Services;
    using Services.Interfaces;

    public class SkillsController : Controller
    {
        private readonly ICVService _cvService;
        private readonly ICVModelService<SkillCreateInputModel, SkillModifyInputModel> _skillsService;
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ICVService cvService, ICVModelService<SkillCreateInputModel, SkillModifyInputModel> skillsService, ILogger<SkillsController> logger)
        {
            _cvService = cvService;
            _skillsService = skillsService;
            _logger = logger;
        }
        
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new SkillCreateInputModel();
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
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
        
        [Authorize]
        public IActionResult Edit(int id)
        {
            var viewModel = _skillsService.GetById<SkillModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SkillModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _skillsService.Edit(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during skill record UPDATE operation for skillId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        [Authorize]
        public IActionResult Delete(int id)
        {
            var viewModel = _skillsService.GetById<SkillModifyInputModel>(id);
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(SkillModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _skillsService.Delete(modifiedModel.Id);
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