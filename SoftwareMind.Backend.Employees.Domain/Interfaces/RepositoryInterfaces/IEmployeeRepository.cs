using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    IQueryable GetQueryFilter(Guid? id = null, string? firstName = null, 
        string? lastName = null, DateTime? dateHireStart = null, DateTime? dateHireEnd = null,
        Guid? departmentId = null);

    IQueryable GetQueryById(Guid id);
}
