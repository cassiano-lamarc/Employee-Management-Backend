using Microsoft.Extensions.DependencyInjection;
using SoftwareMind.Backend.Employees.Application.Services;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Configurations;

public static class DependencyInjectionServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }

}
