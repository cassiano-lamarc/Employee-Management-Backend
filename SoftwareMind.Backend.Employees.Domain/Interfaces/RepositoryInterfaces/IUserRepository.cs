using SoftwareMind.Backend.Employees.Domain.DTO;
using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLogin(LoginRequestDTO requestDTO);
}
