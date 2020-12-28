namespace PersonalWebsite.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.CVModels;
    using Mapping;

    public class SkillModifyInputModel : IMapFrom<Skill>
    {
        public int Id { get; set; }
        
        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}