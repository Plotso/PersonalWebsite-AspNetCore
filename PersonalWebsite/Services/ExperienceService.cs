namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class ExperienceService : IExperienceService
    {
        private readonly IDeletableEntityRepository<Experience> _experienceRepository;
        private readonly IMapper _mapper;

        public ExperienceService(IDeletableEntityRepository<Experience> experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }
        
        public async Task CreateAsync(ExperienceCreateInputModel inputModel, int cvId)
        {
            var experience = _mapper.Map<Experience>(inputModel);
            experience.CVId = cvId;

            await _experienceRepository.AddAsync(experience);
            await _experienceRepository.SaveChangesAsync();
        }
    }
}