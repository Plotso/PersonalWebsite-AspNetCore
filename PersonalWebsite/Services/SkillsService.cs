namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class SkillsService : ISkillsService
    {
        private readonly IDeletableEntityRepository<Skill> _skillsRepository;
        private readonly IMapper _mapper;

        public SkillsService(IDeletableEntityRepository<Skill> skillsRepository, IMapper mapper)
        {
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SkillCreateInputModel inputModel, int cvId)
        {
            var skill = _mapper.Map<Skill>(inputModel);
            skill.CVId = cvId;

            await _skillsRepository.AddAsync(skill);
            await _skillsRepository.SaveChangesAsync();
        }
    }
}