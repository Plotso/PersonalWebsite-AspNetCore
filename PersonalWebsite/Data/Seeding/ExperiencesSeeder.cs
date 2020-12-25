namespace PersonalWebsite.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.Data.CVModels;

    public class ExperiencesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ExperienceRecords.Any())
            {
                return;
            }

            var defaultCV = dbContext.CVs.Single(c => c.Id == 1);

            var experiences = new List<Experience>
            {
                new Experience
                { 
                    Position = "Lead Software Engineer", Company = "DraftKings", Description = 
                        @"DK is one of the leading sports betting solutions providers in the world. As part of the company I was responsible for maintaining and developing distributed systems. Work included several responsibilities:
                  <ul>
                    <li>Develop complex product solutions using scalable distributed systems</li>
                    <li>Improve system monitoring</li>
                    <li>Make architectural redesign of core systems</li>
                    <li>Setup new DataCenters</li>
                  </ul>", 
                    Location = "Boston, Massachusetts, USA", FromDate = new DateTime(2017, 11, 1), ToDate = new DateTime(2020, 11, 30)
                    
                },
                new Experience
                {
                    Position = "Mid Software Developer", Company = "EToro", Description = 
                        @"Working in one of the leading online trading platforms worldwide. Work included several responsibilities:
                  <ul>
                    <li>Improve solutions quality</li>
                    <li>Working directly on integration for new equities and cryptocurrencies</li>
                    <li>Integrate latest technologies</li>
                  </ul>", 
                    Location = "Tel Aviv, Israel", FromDate = new DateTime(2014, 12, 1), ToDate = new DateTime(2017, 9, 30)
                },
                new Experience
                {
                    Position = "Junior Software Developer", Company = "Microsoft", Description = 
                        @"Working on numerous projects during my journey in Microsoft. Most recent one was optimizations of performance for Office 365 platform, fixing issues with OneDrive. Work included several responsibilities:
                  <ul>
                    <li>Write clean and maintainable code</li>
                    <li>Optimise performance for key applications</li>
                    <li>Integrate latest technologies</li>
                  </ul>", 
                    Location = "London, UK", FromDate = new DateTime(2012, 6, 1), ToDate = new DateTime(2014, 7, 31)
                }
            };

            foreach (var experience in experiences)
            {
                experience.CV = defaultCV;
                await dbContext.AddAsync(experience);
            }
        }
    }
}