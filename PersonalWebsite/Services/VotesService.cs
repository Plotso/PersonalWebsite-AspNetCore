namespace PersonalWebsite.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Repositories;
    using Interfaces;
    using Models.Data;

    public class VotesService: IVotesService
    {
        private readonly IRepository<Vote> _votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            _votesRepository = votesRepository;
        }

        public int GetVotes(int commentId)
        {
            var votes = _votesRepository
                .All()
                .Where(v => v.CommentId == commentId)
                .Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int commentId, string userId, bool isUpVote)
        {
            var vote = _votesRepository.All()
                .FirstOrDefault(x => x.CommentId == commentId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    CommentId = commentId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote
                };

                await _votesRepository.AddAsync(vote);
            }

            await _votesRepository.SaveChangesAsync();
        }
    }
}