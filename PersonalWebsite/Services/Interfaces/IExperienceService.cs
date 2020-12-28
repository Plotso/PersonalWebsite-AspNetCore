namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface IExperienceService
    {
        T GetById<T>(int experienceId);

        Task Delete(int experienceId);

        Task Edit(ExperienceModifyInputModel modifiedModel);
        
        Task CreateAsync(ExperienceCreateInputModel inputModel, int cvId);
    }
}