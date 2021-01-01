namespace PersonalWebsite.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using Castle.Core.Logging;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(
            ICommentsService commentsService,
            ICVService cvService,
            UserManager<ApplicationUser> userManager,
            ILogger<CommentsController> logger)
        {
            _commentsService = commentsService;
            _cvService = cvService;
            _userManager = userManager;
            _logger = logger;
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
        [ValidateAntiForgeryToken]
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
        
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = _commentsService.GetById<CommentModifyInputModel>(id);
            var isUserAuthorized = await IsUserAuthorized(viewModel.UserUserName); 
            if (!isUserAuthorized)
            {
                return Unauthorized();
            }
            
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CommentModifyInputModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _commentsService.EditAsync(modifiedModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during comment UPDATE operation for commentId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = _commentsService.GetById<CommentModifyInputModel>(id);
            var isUserAuthorized = await IsUserAuthorized(viewModel.UserUserName); 
            if (!isUserAuthorized)
            {
                return Unauthorized();
            }
            
            return View(viewModel);
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CommentModifyInputModel modifiedModel, string onSubmitAction)
        {
            if (onSubmitAction.IsNullOrEmpty() || onSubmitAction == "Cancel")
            {
                return RedirectToAction(nameof(All));
            }
            
            if (!ModelState.IsValid)
            {
                return View(modifiedModel);
            }

            try
            {
                await _commentsService.DeleteAsync(modifiedModel.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured during comment DELETE operation for commentId: {modifiedModel.Id}.");
                return RedirectToAction("Error", "Home");
            }
            
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

        private async Task<bool> IsUserAuthorized(string commentAuthor)
        {
            var user = await _userManager.GetUserAsync(User);
            var userRoles = await _userManager.GetRolesAsync(user);
            return user.UserName == commentAuthor ||
                   userRoles.Any(r => r == GlobalConstants.AdministratorRoleName);
        }
    }
}
