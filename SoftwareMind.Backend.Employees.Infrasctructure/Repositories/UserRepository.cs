using Microsoft.EntityFrameworkCore;
using SoftwareMind.Backend.Employees.Domain.DTO;
using SoftwareMind.Backend.Employees.Domain.Entities;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Infrasctructure.Context;

namespace SoftwareMind.Backend.Employees.Infrasctructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByLogin(LoginRequestDTO requestDTO) 
        => await _dbSet.FirstOrDefaultAsync(u => u.Login.ToLower().Equals(requestDTO.UserName) && requestDTO.Password.Equals(u.Password));
}
