namespace PersonalWebsite.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using Data;
    using Mapping;

    public class CommentModifyInputModel : IMapFrom<Comment>
    {
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
    }
}