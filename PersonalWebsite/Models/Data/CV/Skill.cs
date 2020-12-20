namespace PersonalWebsite.Models.Data.CV
{
    using System.ComponentModel.DataAnnotations;
    using Abstract;

    public class Skill : BaseDeletableModel<int>
    {
        [Required]
        public string Type { get; set; }  // FE, BackEnd, Infrastructure, Design, SoftSkills and etc

        [Required]
        public string Name { get; set; }

        public int CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}