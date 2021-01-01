namespace PersonalWebsite.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.InputModels;

    public interface ICommentsService
    {
        IEnumerable<T> GetAll<T>(int cvId);
        
        T GetById<T>(int id);

        Task EditAsync(CommentModifyInputModel modifiedModel);
        
        Task DeleteAsync(int id);

        Task CreateAsync(string content, int cvId, string userId);
    }
}