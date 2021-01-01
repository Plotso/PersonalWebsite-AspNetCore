namespace PersonalWebsite.Models.ViewModels.Users
{
    using System;
    using Data.Identity;
    using Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAdmin { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}