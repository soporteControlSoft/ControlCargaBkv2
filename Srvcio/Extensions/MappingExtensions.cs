using AccsoDtos.Mappings;
using AutoMapper;

namespace Srvcio.Extensions;

public static class MappingExtensions
{
    public static void RegisterApiMappings(this IMapperConfigurationExpression config)
    {
        config.AddProfile<AccsoDtos.Mappings.MappingProfile>();
    }
}