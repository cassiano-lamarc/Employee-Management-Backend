using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Department
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; }

    public Department(string description)
    {
        Description = description;
    }
}   
