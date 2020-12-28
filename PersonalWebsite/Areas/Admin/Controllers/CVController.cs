namespace PersonalWebsite.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.ViewModels.Home;
    using PersonalWebsite.Controllers;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize]
    public class CVController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICVService _cvService;

        public CVController(ILogger<HomeController> logger, ICVService cvService) 
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()
        {
            var viewModel = _cvService.GetFirstOrDefault<IndexViewModel>();
            return View(viewModel);
        }
    }
}