using Microsoft.AspNetCore.Http;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;
using System.Security.Claims;

namespace SoftwareMind.Backend.Employees.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId =>
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
}
