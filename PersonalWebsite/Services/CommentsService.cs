namespace PersonalWebsite.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Models.Data;
    using Models.Data.CVModels;
    using PersonalWebsite.Data;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        public IEnumerable<T> GetAll<T>(int cvId)
        {
            var allEntities = _commentsRepository.All();
            var result = allEntities
                .Where(c => c.CVId == cvId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(e => _mapper.Map<T>(e))
                .ToArray();
            return result;
        }

        public async Task CreateAsync(string content, int cvId, string userId)
        {
            var comment = new Comment
            {
                CVId = cvId,
                UserId = userId,
                Content = content
            };

            await _commentsRepository.AddAsync(comment);
            await _commentsRepository.SaveChangesAsync();
        }
    }
}