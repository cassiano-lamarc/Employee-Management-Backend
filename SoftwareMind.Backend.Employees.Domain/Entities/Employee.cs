using SoftwareMind.Backend.Employees.Domain.ObjectValue;

namespace SoftwareMind.Backend.Employees.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string? LastName { get; private set; }
    public DateTime HireDate { get; private set; }
    public Guid DeparmentId { get; private set; }
    public string? Phone { get; private set; }
    public Address? Addresss { get; private set; }

    public virtual Department? Department { get; private set; }
}
