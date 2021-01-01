namespace PersonalWebsite.Models.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common;
    using Data.CVModels;
    using Ganss.XSS;
    using Mapping;

    public class IndexViewModel : IMapFrom<CV>
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string ShortPresentation { get; set; }
        
        public string SanitizedPresentation => new HtmlSanitizer().Sanitize(ShortPresentation);

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public IEnumerable<ExperienceViewModel> ExperienceRecords { get; set; }

        public IEnumerable<EducationViewModel> EducationRecords { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

        public string ProfileImageFileName { get; set; }

        public Dictionary<string, IEnumerable<string>> SkillsByType => Skills.GroupSkillsByType();
    }
}