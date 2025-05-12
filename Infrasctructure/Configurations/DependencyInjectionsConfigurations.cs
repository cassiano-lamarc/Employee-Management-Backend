using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.RepositoryInterfaces;
using Infrasctructure.Repositories.UnitOfWork;
using Infrasctructure.Repositories;

namespace Infrasctructure.Configurations;

public static class DependencyInjectionsConfigurations
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}
