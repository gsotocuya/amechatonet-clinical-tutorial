using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Application.UseCase.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}