namespace PersonalWebsite.Models.CV
{
    using PersonalWebsite.Models.Data.Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CV : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<Experience> Experience { get; set; }

        public ICollection<Education> Education { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
