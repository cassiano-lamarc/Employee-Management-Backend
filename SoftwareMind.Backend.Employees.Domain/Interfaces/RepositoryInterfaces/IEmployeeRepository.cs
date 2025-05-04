using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<List<Employee>> GetByFilter(Guid? id = null, string? firstName = null, string? lastName = null, DateTime? dateHireStart = null, DateTime? dateHireEnd = null, Guid? departmentId = null);
    Task<Employee?> GetByIdTracked(Guid id);
}
