using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Departments.Queries.GetAll;
using Domain.Entities;

namespace API.Controllers;

public class DepartmentController : BaseController
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Department>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDepartmentQuery()));
}
