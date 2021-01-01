namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICVSectionService<TCreate, TModify>
    {
        T GetById<T>(int id);

        Task DeleteAsync(int id);

        Task EditAsync(TModify modifiedModel);
        
        Task CreateAsync(TCreate inputModel, int cvId);
    }
}