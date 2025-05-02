namespace SoftwareMind.Backend.Employees.Domain.ObjectValue;

public class Address
{
    public string? Number { get; private set; }
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? ZipCode { get; private set; }

    public Address(string? number = null, string? street = null, string? city = null, string? state = null, string? zipCode = null)
    {
        Number = number;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}
