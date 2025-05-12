using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Infrasctructure.Context;

namespace Infrasctructure.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}
