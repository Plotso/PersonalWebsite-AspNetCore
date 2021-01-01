namespace PersonalWebsite.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Data.Identity;
    using Models.ViewModels.Users;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UsersController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> All()
        {
            var users = _signInManager.UserManager.Users;
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
        
        private async Task<bool> IsAdminAsync(ApplicationUser user)
        {
            //var user = await _userManager.FindByIdAsync(userModel.Id);
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.Any(r => r == GlobalConstants.AdministratorRoleName);
        }
    }
}