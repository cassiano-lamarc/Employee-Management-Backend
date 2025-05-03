using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareMind.Backend.Employees.Application.Departments.Queries.GetAll;
using SoftwareMind.Backend.Employees.Domain.Entities;
using SoftwareMind.Backend.Employees.Domain.Enums;

namespace SoftwareMind.Backend.Employees.API.Controllers;

public class DepartmentController : BaseController
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = $"{Roles.Reader}, {Roles.Creater}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Department>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDepartmentQuery()));
}
