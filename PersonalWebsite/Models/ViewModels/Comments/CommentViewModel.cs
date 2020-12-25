namespace PersonalWebsite.Models.ViewModels.Comments
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Ganss.XSS;
    using Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IMapExplicitly
    {
        public int Id { get; set; }
        
        public int CVId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(Content); // prevents against cross site scripting (XSS)

        public string UserUserName { get; set; }
        
        public string UserProfilePictureUrl { get; set; }

        public int VotesCount { get; set; }
        
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}