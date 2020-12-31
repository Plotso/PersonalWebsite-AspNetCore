namespace PersonalWebsite.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface ICVService
    {
        T GetFirstOrDefault<T>();

        int GetId();

        Task Edit(CVModifyInputModel modifiedModel);
    }
}