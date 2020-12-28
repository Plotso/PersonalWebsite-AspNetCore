namespace PersonalWebsite.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.CVModels;
    using Mapping;

    public class ExperienceModifyInputModel : IMapFrom<Experience>
    {
        public int Id { get; set; }
        
        [Required]
        public string Position { get; set; }

        [Required]
        public string Company { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }
    }
}