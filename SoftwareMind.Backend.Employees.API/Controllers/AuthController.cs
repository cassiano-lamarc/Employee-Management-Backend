using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareMind.Backend.Employees.Domain.DTO;
using SoftwareMind.Backend.Employees.Domain.Entities;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

namespace SoftwareMind.Backend.Employees.API.Controllers;

public class AuthController : BaseController
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;

    public AuthController(ITokenService tokenService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponseDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Login(LoginRequestDTO request)
    {
        var user = await _userRepository.GetByLogin(request);

        if (user == null)
            return Unauthorized("Invalid Credentials");

        var responseDTO = _tokenService.GenerateToken(user);
        return Ok(responseDTO);
    }
}
