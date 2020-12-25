namespace PersonalWebsite.Models.Data.CVModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abstract;
    using Identity;

    public class CV : BaseModel<int>
    {
        public CV()
        {
            ExperienceRecords = new HashSet<Experience>();
            EducationRecords = new HashSet<Education>();
            Skills = new HashSet<Skill>();
        }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string ShortPresentation { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Location { get; set; }

        public string ProfileImageFileName { get; set; } = "profile_icon.png";

        public virtual ICollection<Experience> ExperienceRecords { get; set; }

        public virtual ICollection<Education> EducationRecords { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
