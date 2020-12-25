namespace PersonalWebsite.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Data.CVModels;

    public interface ICommentsService
    {
        IEnumerable<T> GetAll<T>(int cvId);

        Task CreateAsync(string content, int cvId, string userId);
    }
}