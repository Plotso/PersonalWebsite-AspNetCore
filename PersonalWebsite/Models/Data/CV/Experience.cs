namespace PersonalWebsite.Models.Data.CV
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Abstract;

    public class Experience : BaseDeletableModel<int>
    {
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

        public int CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}