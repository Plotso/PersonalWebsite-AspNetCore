namespace PersonalWebsite.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Repositories;
    using Interfaces;
    using Models.Data.Identity;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> _usersRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IEnumerable<ApplicationUser> GetAllWithDeleted()
        {
            var users = _usersRepository.AllWithDeleted();
            return users;
        }

        public async Task ChangeIsDelete(string email)
        {
            var user = _usersRepository.AllWithDeleted().FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                if (user.IsDeleted)
                {
                    _usersRepository.Undelete(user);
                }
                else
                {
                    _usersRepository.Delete(user);
                }

                await _usersRepository.SaveChangesAsync();
            }
        }
    }
}