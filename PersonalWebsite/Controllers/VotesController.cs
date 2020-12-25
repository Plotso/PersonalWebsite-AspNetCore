namespace PersonalWebsite.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Data.Identity;
    using Models.InputModels;
    using Models.ViewModels;
    using Services;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService _votesService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            _votesService = votesService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = _userManager.GetUserId(User);
            await _votesService.VoteAsync(input.CommentId, userId, input.IsUpVote);

            var votesScore = _votesService.GetVotes(input.CommentId);

            return new VoteResponseModel { VotesCount = votesScore };
        }
    }
}