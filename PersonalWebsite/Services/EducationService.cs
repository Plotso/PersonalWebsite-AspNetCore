namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class EducationService : IEducationService
    {
        private readonly IDeletableEntityRepository<Education> _educationEntityRepository;
        private readonly IMapper _mapper;

        public EducationService(IDeletableEntityRepository<Education> educationEntityRepository, IMapper mapper)
        {
            _educationEntityRepository = educationEntityRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(EducationCreateInputModel inputModel, int cvId)
        {
            var education = _mapper.Map<Education>(inputModel);
            education.CVId = cvId;

            await _educationEntityRepository.AddAsync(education);
            await _educationEntityRepository.SaveChangesAsync();
        }
    }
}