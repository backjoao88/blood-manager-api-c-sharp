using BloodManager.Infrastructure.Persistence.Ef;
using BloodManager.Infrastructure.Persistence.Ef.Repositories;
using BloodManager.Infrastructure.Services;
using Core.Contracts;
using Core.Repositories;
using Core.Services;
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
        services.AddScoped<IPostalCodeService, ViaCepPostalCodeService>();
        return services;
    }
}