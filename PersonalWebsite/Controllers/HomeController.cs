namespace PersonalWebsite.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using Data;
    using Models.ViewModels;
    using Models.ViewModels.Home;
    using Services;
    using Services.Interfaces;

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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
