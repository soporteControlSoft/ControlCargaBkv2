using AutoMapper;

namespace AccesoDatos.Extensions;

public static class MappingExtensions
{
    public static void RegisterAccessMappings(this IMapperConfigurationExpression config)
    {
        config.AddProfile<AccsoDtos.Mappings.MappingProfile >();
    }
}