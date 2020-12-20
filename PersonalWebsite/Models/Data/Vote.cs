namespace PersonalWebsite.Models.Data
{
    using PersonalWebsite.Models.Data.Identity;
    using System.ComponentModel.DataAnnotations;
    using Abstract;

    public class Vote : BaseModel<int>
    {
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
