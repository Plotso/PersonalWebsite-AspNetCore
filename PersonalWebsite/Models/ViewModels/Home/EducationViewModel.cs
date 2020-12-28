namespace PersonalWebsite.Models.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.CVModels;
    using Mapping;

    public class EducationViewModel : IMapFrom<Education>
    {
        public int Id { get; set; }
        
        public string Programme { get; set; }

        public string Degree { get; set; }

        public string School { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")] 
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")] 
        public DateTime ToDate { get; set; }

        [Range(0,4)]
        public double Score { get; set; }
    }
}