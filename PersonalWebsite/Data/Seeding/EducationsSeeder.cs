namespace PersonalWebsite.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.Data.CVModels;

    public class EducationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EducationRecords.Any())
            {
                return;
            }

            var defaultCV = dbContext.CVs.Single(c => c.Id == 1);

            var educationRecords = new List<Education>
            {
                new Education
                {
                    Programme = "Artificial Intelligence", School = "University of Cambridge", Degree = "Master Degree",
                    Score = 4.00, FromDate = new DateTime(2014, 8, 20), ToDate = new DateTime(2016, 12, 23)
                },
                new Education
                {
                    Programme = "Computer Science", School = "University of Cambridge", Degree = "Bachelor Degree",
                    Score = 3.67, FromDate = new DateTime(2010, 8, 22), ToDate = new DateTime(2014, 5, 30)
                },
                new Education
                {
                    Programme = "Software Engineering", School = "SoftUni", Degree = "Bachelor Degree", Score = 4.00,
                    FromDate = new DateTime(2018, 8, 20), ToDate = new DateTime(2020, 9, 3)
                }
            };

            foreach (var education in educationRecords)
            {
                education.CV = defaultCV;
                await dbContext.AddAsync(education);
            }
        }
    }
}