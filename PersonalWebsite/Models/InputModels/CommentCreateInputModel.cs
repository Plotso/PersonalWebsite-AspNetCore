namespace PersonalWebsite.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentCreateInputModel
    {
        [Required]
        public string Content { get; set; }
    }
}