namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface ISkillsService
    {
        T GetById<T>(int skillId);

        Task Delete(int skillId);

        Task Edit(SkillModifyInputModel modifiedModel);
        
        Task CreateAsync(SkillCreateInputModel inputModel, int cvId);
    }
}