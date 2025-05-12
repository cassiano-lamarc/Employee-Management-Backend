using Microsoft.EntityFrameworkCore;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Infrasctructure.Context;

namespace Infrasctructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByLogin(LoginRequestDTO requestDTO) 
        => await _dbSet.FirstOrDefaultAsync(u => u.Login.ToLower().Equals(requestDTO.UserName) && requestDTO.Password.Equals(u.Password));
}
