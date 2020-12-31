namespace PersonalWebsite.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Repositories;
    using Interfaces;
    using Models.Data.CVModels;
    using Models.InputModels;

    public class SkillsService : ICVSectionService<SkillCreateInputModel, SkillModifyInputModel>
    {
        private readonly IDeletableEntityRepository<Skill> _skillsRepository;
        private readonly IMapper _mapper;

        public SkillsService(IDeletableEntityRepository<Skill> skillsRepository, IMapper mapper)
        {
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public T GetById<T>(int skillId)
        {
            var skill = _skillsRepository.All().FirstOrDefault(e => e.Id == skillId);
            return _mapper.Map<T>(skill);
        }

        public async Task Delete(int skillId)
        {
            var skill = _skillsRepository.All().FirstOrDefault(e => e.Id == skillId);
            if (skill != null)
            {
                _skillsRepository.Delete(skill);
                await _skillsRepository.SaveChangesAsync();
            }
        }

        public async Task Edit(SkillModifyInputModel modifiedModel)
        {
            var skill = _skillsRepository.All().FirstOrDefault(e => e.Id == modifiedModel.Id);
            if (skill != null)
            {
                skill.Type = modifiedModel.Type;
                skill.Name = modifiedModel.Name;
                
                _skillsRepository.Update(skill);
                await _skillsRepository.SaveChangesAsync();
            }
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