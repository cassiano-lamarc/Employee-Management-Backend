using SoftwareMind.Backend.Employees.Domain.ObjectValue;

namespace SoftwareMind.Backend.Employees.Application.DTOs;

public class EmployeeDTO
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? HireDate { get; set; }
    public Guid DeparmentId { get; set; }
    public string? Phone { get; set; }
    public Address? Addresss { get; set; }
    public DateTime CreatedDate { get; }
    public Guid CreatedUserId { get; set; }
    public Guid? UpdatedUserId { get; set; }
    public string? AvatarUrl { get; set; }
    public string? DepartmentDescription { get; set; }
    public string? CreatedUserName { get; set; }
    public string? UpdatedUserName { get; set; }
}
