namespace PersonalWebsite.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Data.Identity;

    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAllWithDeleted();
        
        Task ChangeIsDelete(string email);
    }
}