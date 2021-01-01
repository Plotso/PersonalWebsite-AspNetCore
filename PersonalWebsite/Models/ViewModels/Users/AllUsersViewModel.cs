namespace PersonalWebsite.Models.ViewModels.Users
{
    using System.Collections.Generic;

    public class AllUsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}