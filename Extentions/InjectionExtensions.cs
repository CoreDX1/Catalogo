using Catalogo.Models.Interfaces;
using Catalogo.Repository;
using Catalogo.Services;

namespace Catalogo.Extentions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApi(this IServiceCollection services)
    {
        // Productos
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddScoped<IProductServices, ProductServices>();

        return services;
    }
}
