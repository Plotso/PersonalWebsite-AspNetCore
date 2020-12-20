namespace PersonalWebsite.Services
{
    using System.Linq;
    using Data;

    public class NameService : INameService
    {
        private readonly ApplicationDbContext _dbContext;

        public NameService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public string GetOwnersName()
        {
            var pageOwnerName = _dbContext.CVs.FirstOrDefault();
            return pageOwnerName?.Name;
        }
    }
}