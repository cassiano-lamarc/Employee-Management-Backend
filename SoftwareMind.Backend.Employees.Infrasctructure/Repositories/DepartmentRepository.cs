using SoftwareMind.Backend.Employees.Domain.Entities;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Infrasctructure.Context;

namespace SoftwareMind.Backend.Employees.Infrasctructure.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}
