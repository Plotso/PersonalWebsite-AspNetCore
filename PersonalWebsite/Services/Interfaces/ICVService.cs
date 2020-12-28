namespace PersonalWebsite.Services.Interfaces
{
    public interface ICVService
    {
        T GetFirstOrDefault<T>();

        int GetId();
    }
}