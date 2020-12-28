namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface IEducationService
    {
        T GetById<T>(int educationId);

        Task Delete(int educationId);

        Task Edit(EducationModifyInputModel modifiedModel);
        
        Task CreateAsync(EducationCreateInputModel inputModel, int cvId);
    }
}