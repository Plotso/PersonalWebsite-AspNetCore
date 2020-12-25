namespace PersonalWebsite.Models.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CVModels;
    using Abstract;
    using Identity;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            Votes = new HashSet<Vote>();
        }
        
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CVId { get; set; }

        public virtual CV CV { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
