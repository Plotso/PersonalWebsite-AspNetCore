namespace PersonalWebsite.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        IEnumerable<T> GetAll<T>(int cvId);

        Task CreateAsync(string content, int cvId, string userId);
    }
}