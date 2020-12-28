namespace PersonalWebsite.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.CVModels;
    using Mapping;

    public class EducationModifyInputModel : IMapFrom<Education>
    {
        public int Id { get; set; }
        
        [Required]
        public string Programme { get; set; }

        [Required]
        public string Degree { get; set; } 

        [Required]
        public string School { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Range(0,4)]
        public double Score { get; set; }
    }
}