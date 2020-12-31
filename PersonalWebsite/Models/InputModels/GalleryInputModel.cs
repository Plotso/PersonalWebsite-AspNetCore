namespace PersonalWebsite.Models.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Microsoft.AspNetCore.Http;

    public class GalleryInputModel : IValidatableObject
    {
        [Required]
        public IFormFile Image { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validImageExtensions = new [] { ".jpeg", ".jpg", ".png", ".gif" };
            if (Image != null && !validImageExtensions.Any(x => Image.FileName.EndsWith(x)))
            {
                yield return new ValidationResult("Valid file extensions for an image are .jpeg/jpg/png/gif");
            }
        }
    }
}