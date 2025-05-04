using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;
using SoftwareMind.Backend.Employees.Application.Employee.Commands.Delete;
using SoftwareMind.Backend.Employees.Application.Employee.Commands.Update;
using SoftwareMind.Backend.Employees.Application.Employee.Queries.GetByQuery;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

namespace SoftwareMind.Backend.Employees.API.Controllers;

public class EmployeeController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IUploadFileService _uploadFileService;

    public EmployeeController(IMediator mediator, IUploadFileService uploadFileService)
    {
        _mediator = mediator;
        _uploadFileService = uploadFileService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task CreateEmployee([FromBody] CreateEmployeeCommand createRequest)
    {
        await _mediator.Send(createRequest);
        Created();
    }

    [HttpGet("/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Domain.Entities.Employee))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
        => Ok(await _mediator.Send(new GetEmployeeQuery(id)));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Domain.Entities.Employee>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetEmployees([FromQuery] GetEmployeeQuery getEmployeeQuery)
        => Ok(await _mediator.Send(getEmployeeQuery));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Domain.Entities.Employee))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CreateEmployee([FromBody] UpdateEmployeeCommand updateRequest)
    => Ok(await _mediator.Send(updateRequest));

    [HttpDelete("/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        => Ok(await _mediator.Send(new DeleteEmployeeCommand(id)));

    [HttpPost("upload-avatar/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UploadAvatar(IFormFile file, [FromRoute] string employeeId)
        => Ok(await _uploadFileService.UploadAvatar(file, Guid.Parse(employeeId)));
}
