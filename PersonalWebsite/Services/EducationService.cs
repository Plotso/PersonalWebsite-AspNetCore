namespace PersonalWebsite.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Interfaces;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class EducationService : ICVSectionService<EducationCreateInputModel, EducationModifyInputModel>
    {
        private readonly IDeletableEntityRepository<Education> _educationEntityRepository;
        private readonly IMapper _mapper;

        public EducationService(IDeletableEntityRepository<Education> educationEntityRepository, IMapper mapper)
        {
            _educationEntityRepository = educationEntityRepository;
            _mapper = mapper;
        }

        public T GetById<T>(int educationId)
        {
            var education = _educationEntityRepository.All().FirstOrDefault(e => e.Id == educationId);
            return _mapper.Map<T>(education);
        }

        public async Task Delete(int educationId)
        {
            var education = _educationEntityRepository.All().FirstOrDefault(e => e.Id == educationId);
            if (education != null)
            {
                _educationEntityRepository.Delete(education);
                await _educationEntityRepository.SaveChangesAsync();
            }
        }

        public async Task Edit(EducationModifyInputModel modifiedModel)
        {
            var education = _educationEntityRepository.All().FirstOrDefault(e => e.Id == modifiedModel.Id);
            if (education != null)
            {
                education.Programme = modifiedModel.Programme;
                education.Degree = modifiedModel.Degree;
                education.School = modifiedModel.School;
                education.FromDate = modifiedModel.FromDate;
                education.ToDate = modifiedModel.ToDate;
                education.Score = modifiedModel.Score;
                
                _educationEntityRepository.Update(education);
                await _educationEntityRepository.SaveChangesAsync();
            }
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