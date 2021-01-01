namespace PersonalWebsite.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Interfaces;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class ExperienceService : ICVSectionService<ExperienceCreateInputModel, ExperienceModifyInputModel>
    {
        private readonly IDeletableEntityRepository<Experience> _experienceRepository;
        private readonly IMapper _mapper;

        public ExperienceService(IDeletableEntityRepository<Experience> experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public T GetById<T>(int experienceId)
        {
            var experience = _experienceRepository.All().FirstOrDefault(e => e.Id == experienceId);
            return _mapper.Map<T>(experience);
        }

        public async Task DeleteAsync(int experienceId)
        {
            var experience = _experienceRepository.All().FirstOrDefault(e => e.Id == experienceId);
            if (experience != null)
            {
                _experienceRepository.Delete(experience);
                await _experienceRepository.SaveChangesAsync();
            }
        }

        public async Task EditAsync(ExperienceModifyInputModel modifiedModel)
        {
            var experience = _experienceRepository.All().FirstOrDefault(e => e.Id == modifiedModel.Id);
            if (experience != null)
            {
                experience.Position = modifiedModel.Position;
                experience.Company = modifiedModel.Company;
                experience.FromDate = modifiedModel.FromDate;
                experience.ToDate = modifiedModel.ToDate;
                experience.Location = modifiedModel.Location;
                experience.Description = modifiedModel.Description;
                
                _experienceRepository.Update(experience);
                await _experienceRepository.SaveChangesAsync();
            }
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