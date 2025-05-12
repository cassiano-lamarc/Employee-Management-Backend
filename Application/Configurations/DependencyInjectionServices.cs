using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Domain.Interfaces.ServiceInterfaces;

namespace Application.Configurations;

public static class DependencyInjectionServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IUploadFileService, UploadFileService>();

        return services;
    }

}
