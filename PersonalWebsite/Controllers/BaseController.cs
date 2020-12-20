namespace PersonalWebsite.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class BaseController : Controller
    {
        private readonly INameService _nameService;

        public BaseController(INameService nameService)
        {
            _nameService = nameService;
        }

        public void SetOwnerName()
        {
            ViewData["PageOwnerName"] = _nameService.GetOwnersName();
        }
    }
}