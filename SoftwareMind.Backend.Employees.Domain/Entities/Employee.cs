using SoftwareMind.Backend.Employees.Domain.Exceptions;
using SoftwareMind.Backend.Employees.Domain.ObjectValue;

namespace SoftwareMind.Backend.Employees.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public int Number { get; private set; }
    public string FirstName { get; private set; }
    public string? LastName { get; private set; }
    public DateTime? HireDate { get; private set; }
    public Guid DeparmentId { get; private set; }
    public string? Phone { get; private set; }
    public Address? Addresss { get; private set; }
    public DateTime CreatedDate { get; }
    public Guid CreatedUserId { get; private set; }
    public Guid? UpdatedUserId { get; private set; }
    public string AvatarUrl { get; private set; }

    public virtual Department Department { get; private set; }
    public virtual User CreatedUser { get; private set; }
    public virtual User? UpdatedUser { get; private set; }

    protected Employee() { }

    private Employee(Guid id, string firstName, string lastName, string phone, Guid departmentId, Guid createdUserId, Guid? updatedUserId = null, DateTime ? hireDate = null, Address? address = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        DeparmentId = departmentId;
        HireDate = hireDate;
        Addresss = address;
        CreatedUserId = createdUserId;
        UpdatedUserId = updatedUserId;

        if (string.IsNullOrWhiteSpace(firstName)) throw new BusinessException("First name is required");
        if (departmentId == Guid.Empty) throw new BusinessException("Department is required");
    }


    public static Employee Create(string firstName, string lastName, string phone, Guid departmentId, Guid createdUserId, DateTime? hireDate = null, Address? address = null)
    {
        return new Employee(Guid.NewGuid(), firstName, lastName, phone, departmentId, createdUserId, null, hireDate, address);
    }

    public void Update(string firstName, string lastName, string phone, Guid departmentId, Guid updatedUserId)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        DeparmentId = departmentId;
        UpdatedUserId = updatedUserId;
    }

    public void UpdateAvatarUrl(string url) => AvatarUrl = url;
}
