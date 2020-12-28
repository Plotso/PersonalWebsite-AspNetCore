namespace PersonalWebsite.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Data.Identity;
    using Models.InputModels;
    using Models.ViewModels.Comments;
    using Services;
    using Services.Interfaces;

    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        private readonly ICVService _cvService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ICommentsService commentsService, ICVService cvService, UserManager<ApplicationUser> userManager)
        {
            _commentsService = commentsService;
            _cvService = cvService;
            _userManager = userManager;
        }
        
        public IActionResult All()
        {
            var defaultCvId = _cvService.GetId();
            var viewModel = new AllCommentsViewModel
            {
                Comments = _commentsService.GetAll<CommentViewModel>(defaultCvId),
                InputModel = new CommentCreateInputModel()
            };
            
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AllCommentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return AllWithInputModel(model.InputModel);
            }

            var defaultCvId = _cvService.GetId();
            var user = await _userManager.GetUserAsync(User);
            await _commentsService.CreateAsync(model.InputModel.Content, defaultCvId, user.Id);

            return RedirectToAction(nameof(All));
        }

        private IActionResult AllWithInputModel(CommentCreateInputModel inputModel)
        {
            var defaultCvId = _cvService.GetId();
            var viewModel = new AllCommentsViewModel
            {
                Comments = _commentsService.GetAll<CommentViewModel>(defaultCvId),
                InputModel = inputModel
            };
            
            return View("All", viewModel);
        }
    }
}
