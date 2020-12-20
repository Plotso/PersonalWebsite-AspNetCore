namespace PersonalWebsite.Models.ViewModels.Home
{
    using Data.CV;
    using Mapping;

    public class SkillViewModel : IMapFrom<Skill>
    {
        public string Type { get; set; }

        public string Name { get; set; }
    }
}