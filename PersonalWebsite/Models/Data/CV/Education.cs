﻿namespace PersonalWebsite.Models.Data.CV
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Abstract;

    public class Education : BaseDeletableModel<int>
    {
        [Required]
        public string Programme { get; set; }

        [Required]
        public string Degree { get; set; } // Bachelor, Master, Phd

        [Required]
        public string School { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Range(0,4)]
        public double Score { get; set; }

        public int CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}