namespace SoftwareMind.Backend.Employees.Domain.Entities;

public class Department
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public Department(string description)
    {
        Description = description;
    }
}   
