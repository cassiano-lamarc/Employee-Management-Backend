using Microsoft.EntityFrameworkCore;
using SoftwareMind.Backend.Employees.Domain.Entities;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Infrasctructure.Context;

namespace SoftwareMind.Backend.Employees.Infrasctructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) { }

    public async Task<List<Employee>> GetByFilter(Guid? id = null, string? firstName = null, string? lastName = null,
            DateTime? dateHireStart = null, DateTime? dateHireEnd = null, Guid? departmentId = null)
    {
        return await _context.Employees
            .Where(x =>
                (!id.HasValue || x.Id == id) &&
                (string.IsNullOrEmpty(firstName) || x.FirstName.Contains(firstName)) &&
                (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(x.LastName) || x.LastName.Contains(lastName)) &&
                (!dateHireStart.HasValue || x.HireDate >= dateHireStart.Value) &&
                (!dateHireEnd.HasValue || x.HireDate <= dateHireEnd.Value) &&
                (!departmentId.HasValue || x.DeparmentId == departmentId.Value))
            .ToListAsync();
     }
}
