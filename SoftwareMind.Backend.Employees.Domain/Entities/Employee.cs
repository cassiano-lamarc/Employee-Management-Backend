using SoftwareMind.Backend.Employees.Domain.ObjectValue;

namespace SoftwareMind.Backend.Employees.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string? LastName { get; private set; }
    public DateTime? HireDate { get; private set; }
    public Guid DeparmentId { get; private set; }
    public string? Phone { get; private set; }
    public Address? Addresss { get; private set; }

    public virtual Department? Department { get; private set; }

    protected Employee() { }

    private Employee(Guid id, string firstName, string lastName, string phone, Guid departmentId, DateTime? hireDate = null, Address? address = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        DeparmentId = departmentId;
        HireDate = hireDate;
        Addresss = address;

        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is required");
        if (departmentId == Guid.Empty) throw new ArgumentException("Department is required");
    }

    public static Employee Create(string firstName, string lastName, string phone, Guid departmentId, DateTime? hireDate = null, Address? address = null)
    {
        var id = Guid.NewGuid();
        return new Employee(id, firstName, lastName, phone, departmentId, hireDate, address);
    }

    public static Employee Update(Guid id, string firstName, string lastName, string phone, Guid departmentId, DateTime? hireDate = null, Address? address = null)
    {
        return new Employee(id, firstName, lastName, phone, departmentId, hireDate, address);
    }
}
