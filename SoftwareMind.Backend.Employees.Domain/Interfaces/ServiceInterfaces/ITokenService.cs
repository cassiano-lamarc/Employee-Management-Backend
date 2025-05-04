using SoftwareMind.Backend.Employees.Domain.DTO;
using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

public interface ITokenService
{
    public LoginResponseDTO GenerateToken(User user);
}
