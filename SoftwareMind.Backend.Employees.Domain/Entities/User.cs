namespace SoftwareMind.Backend.Employees.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }

    public virtual ICollection<Employee>? CreatedEmployees { get; set; }
    public virtual ICollection<Employee>? UpdatedEmployees { get; set; }
}
