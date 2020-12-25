namespace PersonalWebsite.Services
{
    using System.Threading.Tasks;

    public interface ICVService
    {
        T GetFirstOrDefault<T>();

        int GetId();
    }
}