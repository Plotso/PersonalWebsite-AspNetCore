namespace PersonalWebsite.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models.Data.Identity;
    using Models.ViewModels.Users;
    using Services.Interfaces;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            IMapper mapper, 
            IUserService userService,
            ILogger<UsersController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }
        
        public async Task<IActionResult> All()
        {
            //var users = _signInManager.UserManager.Users;  //Filters deleted
            var users = _userService.GetAllWithDeleted();
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var isAdmin = await IsAdminAsync(user);
                var userModel = _mapper.Map<UserViewModel>(user);
                userModel.IsAdmin = isAdmin;
                userViewModels.Add(userModel);
            }
            
            var viewModel = new AllUsersViewModel
            {
                Users = userViewModels
            };
            return View(viewModel);
        }

        public async Task<IActionResult> EditUserRole(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Any(r => r == GlobalConstants.AdministratorRoleName))
            {
                await _userManager.RemoveFromRoleAsync(user, GlobalConstants.AdministratorRoleName);
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser.Id == user.Id)
                {
                    await _signInManager.SignOutAsync();
                }
            }
            else
            {
                await _userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }


            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> EditUserIsDeletedStatus(string email)
        {
            try
            {
                await _userService.ChangeIsDelete(email);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured during new education record creation.");
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction(nameof(All));
        }
        
        private async Task<bool> IsAdminAsync(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.Any(r => r == GlobalConstants.AdministratorRoleName);
        }
    }
}