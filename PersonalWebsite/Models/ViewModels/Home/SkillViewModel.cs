namespace PersonalWebsite.Models.ViewModels.Home
{
    using Data.CVModels;
    using Mapping;

    public class SkillViewModel : IMapFrom<Skill>
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }
    }
}