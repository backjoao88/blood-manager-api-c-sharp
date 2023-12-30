using BloodManager.Infrastructure.Persistence.Ef;
using BloodManager.Infrastructure.Persistence.Ef.Repositories;
using Core.Contracts;
using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BloodManager.Infrastructure;

/// <summary>
/// Dependency injection for the infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<EfCoreContext>();
        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IDonationRepository, DonationRepository>();
        services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
        return services;
    }
}