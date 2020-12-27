namespace PersonalWebsite.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Services;

    public class SkillsController : Controller
    {
        private readonly ICVService _cvService;
        private readonly ISkillsService _skillsService;
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ICVService cvService, ISkillsService skillsService, ILogger<SkillsController> logger)
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
    }
}