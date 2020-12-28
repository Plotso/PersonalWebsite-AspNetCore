namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;

    //ToDo: Move experience, education and skills to be using this interface
    public interface ICVModelService<TCreate, TModify>
    {
        T GetById<T>(int id);

        Task Delete(int id);

        Task Edit(TModify modifiedModel);
        
        Task CreateAsync(TCreate inputModel, int cvId);
    }
}