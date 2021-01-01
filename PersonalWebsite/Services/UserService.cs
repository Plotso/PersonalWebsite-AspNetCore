namespace PersonalWebsite.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Repositories;
    using Interfaces;
    using Models.Data.Identity;

    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _usersRepository;

        public UserService(IRepository<ApplicationUser> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public IEnumerable<ApplicationUser> GetAll()
        {
            var users = _usersRepository.All();
            return users.ToArray();
        }
    }
}