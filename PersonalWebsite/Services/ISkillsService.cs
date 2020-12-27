namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface ISkillsService
    {
        Task CreateAsync(SkillCreateInputModel inputModel, int cvId);
    }
}