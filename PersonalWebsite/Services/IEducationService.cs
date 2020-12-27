namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface IEducationService
    {
        Task CreateAsync(EducationCreateInputModel inputModel, int cvId);
    }
}