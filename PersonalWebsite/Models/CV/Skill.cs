namespace PersonalWebsite.Models.CV
{
    using PersonalWebsite.Models.Data.Abstract;
    using System.ComponentModel.DataAnnotations;

    public class Skill : BaseDeletableModel<int>
    {
        [Required]
        public string Type { get; set; }  // FE, BackEnd, Infrastructure, Design, SoftSkills and etc

        [Required]
        public string Name { get; set; }

        public int CVId { get; set; }

        public CV CV { get; set; }
    }
}