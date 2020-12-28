namespace PersonalWebsite.Areas.Admin.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.ViewModels;
    using Models.ViewModels.Home;
    using PersonalWebsite.Controllers;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<PersonalWebsite.Controllers.HomeController> _logger;
        private readonly ICVService _cvService;

        public HomeController(ILogger<PersonalWebsite.Controllers.HomeController> logger, ICVService cvService) 
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()  //ToDo: Add delete icon for routing to delete actions of each individual cv component
        {
            var viewModel = _cvService.GetFirstOrDefault<IndexViewModel>();
            return View(viewModel);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}