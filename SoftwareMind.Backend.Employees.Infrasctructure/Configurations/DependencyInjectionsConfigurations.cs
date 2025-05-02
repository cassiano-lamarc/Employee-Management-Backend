using Microsoft.Extensions.DependencyInjection;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Infrasctructure.Repositories.UnitOfWork;
using SoftwareMind.Backend.Employees.Infrasctructure.Repositories;

namespace SoftwareMind.Backend.Employees.Infrasctructure.Configurations;

public static class DependencyInjectionsConfigurations
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}
