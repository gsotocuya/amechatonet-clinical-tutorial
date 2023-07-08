using CLINICAL.Application.Interfaces;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistence.Extension;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();
        services.AddScoped<IAnalysisRepository, AnalysisRepository>();
        return services;
    }
}