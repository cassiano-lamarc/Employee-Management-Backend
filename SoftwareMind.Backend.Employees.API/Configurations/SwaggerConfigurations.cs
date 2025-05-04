using Microsoft.OpenApi.Models;

namespace SoftwareMind.Backend.Employees.API.Configurations;

public static class SwaggerConfigurations
{
    public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insert the token JWT formatted as: Bearer {your token}"
            });
        });

        return services;
    }
}
