using Microsoft.Extensions.DependencyInjection;
using SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;

namespace SoftwareMind.Backend.Employees.Application.Configurations;

public static class DependencyInjectionMediatR
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommand).Assembly));

        return services;
    }
}
