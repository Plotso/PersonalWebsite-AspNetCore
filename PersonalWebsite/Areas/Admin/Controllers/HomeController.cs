namespace PersonalWebsite.Areas.Admin.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.InputModels;
    using Models.ViewModels;
    using Models.ViewModels.Home;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICVService _cvService;

        public HomeController(ILogger<HomeController> logger, ICVService cvService) 
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()
        {
            var viewModel = _cvService.GetFirstOrDefault<IndexViewModel>();
            return View(viewModel);
        }
        
        public IActionResult Edit(int id)
        {
            var viewModel = _cvService.GetFirstOrDefault<CVModifyInputModel>();
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CVModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _cvService.Edit(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during education record UPDATE operation for main CV: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}