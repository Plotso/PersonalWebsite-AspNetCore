namespace PersonalWebsite.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore.Internal;
    using Models.Data.CVModels;

    public class CVSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CVs.Any())
            {
                return;
            }
            
            var CV = new CV
            {
                Name = "John Warner",
                Position = "Software Engineer",
                ShortPresentation = "Young and ambitious software developer with high interest in developing complex new products for gaming industries.",
                Phone = "0881234567",
                Email = "john.warner@gmail.com",
                Location = "London, UK"
            };

            await dbContext.CVs.AddAsync(CV);
        }
    }
}