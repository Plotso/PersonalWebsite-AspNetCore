namespace PersonalWebsite.Mapping
{
    using System;
    using System.Linq;
    using AutoMapper;

    public class ConventionalMappingProfile : Profile
    {
        public ConventionalMappingProfile()
        {
            var mapFromType = typeof(IMapFrom<>);
            var mapToType = typeof(IMapTo<>);
            var explicitMapType = typeof(IMapExplicitly);

            var modelMappingRegistrations = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName()?.Name?.StartsWith(nameof(PersonalWebsite)) ?? false)
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Type = t,
                    MapFrom = GetMappingModel(t, mapFromType),
                    MapTo = GetMappingModel(t , mapToType),
                    ExplicitMap = t.GetInterfaces()
                        .Where(i => i == explicitMapType)
                        .Select(i => (IMapExplicitly)Activator.CreateInstance(t))
                        .FirstOrDefault()
                });

            foreach (var modelMappingRegistration in modelMappingRegistrations)
            {
                if (modelMappingRegistration.MapFrom != null)
                {
                    CreateMap(modelMappingRegistration.MapFrom, modelMappingRegistration.Type);
                }
                
                if (modelMappingRegistration.MapTo != null)
                {
                    CreateMap(modelMappingRegistration.Type, modelMappingRegistration.MapTo);
                }
                
                modelMappingRegistration.ExplicitMap?.CreateMappings(this);
            }
        }
        
        private static Type GetMappingModel(Type type, Type mappingInterface)
            => type.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingInterface)
                ?.GetGenericArguments()
                .First();
    }
}