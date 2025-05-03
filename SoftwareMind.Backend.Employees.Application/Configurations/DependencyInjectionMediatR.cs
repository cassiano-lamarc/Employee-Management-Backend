using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;

namespace SoftwareMind.Backend.Employees.Application.Configurations;

public static class DependencyInjectionMediatR
{
    public static IServiceCollection AddApplicationMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateEmployeeCommand).Assembly);

        return services;
    }
}
