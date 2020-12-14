namespace PersonalWebsite.Models.Data
{
    using PersonalWebsite.Models.Data.Abstract;
    using PersonalWebsite.Models.Data.Identity;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
