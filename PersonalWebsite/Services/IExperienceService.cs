namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface IExperienceService
    {
        Task CreateAsync(ExperienceCreateInputModel inputModel, int cvId);
    }
}