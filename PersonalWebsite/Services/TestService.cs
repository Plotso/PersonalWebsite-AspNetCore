namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    using Models.InputModels;

    //ToDo: Delete
    public class TestService : ICVModelService<EducationCreateInputModel, EducationModifyInputModel>
    {
        public T GetById<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(EducationModifyInputModel modifiedModel)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(EducationCreateInputModel inputModel, int cvId)
        {
            throw new System.NotImplementedException();
        }
    }
}