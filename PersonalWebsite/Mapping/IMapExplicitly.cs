namespace PersonalWebsite.Mapping
{
    using AutoMapper;

    public interface IMapExplicitly
    {
        void CreateMappings(IProfileExpression configuration);
    }
}