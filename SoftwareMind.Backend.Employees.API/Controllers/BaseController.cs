using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareMind.Backend.Employees.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BaseController : Controller
{
}
