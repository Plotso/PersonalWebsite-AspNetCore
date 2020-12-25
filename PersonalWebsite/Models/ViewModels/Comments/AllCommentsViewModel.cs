namespace PersonalWebsite.Models.ViewModels.Comments
{
    using System.Collections.Generic;
    using InputModels;

    public class AllCommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        
        public CommentCreateInputModel InputModel { get; set; }
    }
}