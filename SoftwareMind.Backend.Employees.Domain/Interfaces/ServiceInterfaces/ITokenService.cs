using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
}
