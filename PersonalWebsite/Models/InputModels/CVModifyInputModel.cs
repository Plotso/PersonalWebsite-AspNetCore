namespace PersonalWebsite.Models.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Data.CVModels;
    using Mapping;
    using Microsoft.AspNetCore.Http;

    public class CVModifyInputModel : IMapFrom<CV>, IValidatableObject
    {
        public int Id { get; set; }
        
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
        
        public IFormFile NewCVPicture { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validImageExtensions = new [] { ".jpeg", ".jpg", ".png", ".gif" };
            if (NewCVPicture != null && !validImageExtensions.Any(x => NewCVPicture.FileName.EndsWith(x)))
            {
                yield return new ValidationResult("Valid file extensions for an image are .jpeg/jpg/png/gif");
            }
        }
    }
}