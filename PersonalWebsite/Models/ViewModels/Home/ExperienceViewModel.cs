namespace PersonalWebsite.Models.ViewModels.Home
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.CVModels;
    using Ganss.XSS;
    using Mapping;

    public class ExperienceViewModel : IMapFrom<Experience>
    {
        public int Id { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")] 
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")] 
        public DateTime ToDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        
        public string SanitizedDescription => new HtmlSanitizer().Sanitize(Description);
    }
}