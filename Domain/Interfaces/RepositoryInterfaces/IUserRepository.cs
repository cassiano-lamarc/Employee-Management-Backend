using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLogin(LoginRequestDTO requestDTO);
}
