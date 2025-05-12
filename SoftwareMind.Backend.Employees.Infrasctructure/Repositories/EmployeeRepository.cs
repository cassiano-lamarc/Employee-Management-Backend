using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Infrasctructure.Context;

namespace Infrasctructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) { }

    public IQueryable GetQueryFilter(Guid? id = null, string? firstName = null,
        string? lastName = null, DateTime? dateHireStart = null, DateTime? dateHireEnd = null,
        Guid? departmentId = null)
        => _dbSet.AsNoTracking()
            .Where(x =>
                (!id.HasValue || x.Id == id) &&
                (string.IsNullOrEmpty(firstName) || x.FirstName.Contains(firstName)) &&
                (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(x.LastName) || x.LastName.Contains(lastName)) &&
                (!dateHireStart.HasValue || x.HireDate >= dateHireStart.Value) &&
                (!dateHireEnd.HasValue || x.HireDate <= dateHireEnd.Value) &&
                (!departmentId.HasValue || x.DeparmentId == departmentId.Value));

    public IQueryable GetQueryById(Guid id)
        => _dbSet.AsNoTracking().Where(e => e.Id.Equals(id));
}
