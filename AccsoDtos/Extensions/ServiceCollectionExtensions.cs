
using Microsoft.Extensions.DependencyInjection;

namespace AccesoDatos.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterAccessDatosServices(this IServiceCollection services)
    {
        //services.AddTransient<IProductos, Productos>();
        //services.AddTransient<IPlaneacionProduccion, PlaneacionProduccion>();
        //ervices.AddTransient<IHistoricoRutas, HistoricoRutas>();
    }
}
