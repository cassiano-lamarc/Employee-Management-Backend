using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces.ServiceInterfaces;

public interface ITokenService
{
    public LoginResponseDTO GenerateToken(User user);
}
