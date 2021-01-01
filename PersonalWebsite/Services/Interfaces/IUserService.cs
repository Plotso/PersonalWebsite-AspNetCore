namespace PersonalWebsite.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.Data.Identity;

    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAll();
    }
}