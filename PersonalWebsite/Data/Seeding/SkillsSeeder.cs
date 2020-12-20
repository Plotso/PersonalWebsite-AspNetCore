namespace PersonalWebsite.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.Data.CV;

    public class SkillsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Skills.Any())
            {
                return;
            }

            var defaultCV = dbContext.CVs.Single(c => c.Id == 1);

            var skills = new List<Skill>
            {
                new Skill {Type = "Infrastructure", Name = "Consul"},
                new Skill {Type = "Infrastructure", Name = "Fabio"},
                new Skill {Type = "Infrastructure", Name = "Docker"},
                new Skill {Type = "Infrastructure", Name = "K8s"},
                new Skill {Type = "Backend", Name = "C#"},
                new Skill {Type = "Backend", Name = "SQL"},
                new Skill {Type = "Backend", Name = "MongoDB"},
                new Skill {Type = "Backend", Name = "Kafka"},
                new Skill {Type = "Backend", Name = ".NET Core"},
                new Skill {Type = "Backend", Name = "ASP.NET Core"},
                new Skill {Type = "Backend", Name = "Entity Framework Core"},
                new Skill {Type = "Frontend", Name = "JavaScript"},
                new Skill {Type = "Frontend", Name = "jQuery"},
                new Skill {Type = "Frontend", Name = "VueJS"},
                new Skill {Type = "Frontend", Name = "Blazor"}
            };

            foreach (var skill in skills)
            {
                skill.CV = defaultCV;
                await dbContext.AddAsync(skill);
            }
        }
    }
}