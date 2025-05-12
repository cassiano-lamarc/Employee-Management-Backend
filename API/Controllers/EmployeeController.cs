using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Employee.Commands.Create;
using Application.Employee.Commands.Delete;
using Application.Employee.Commands.Update;
using Application.Employee.Queries.GetById;
using Application.Employee.Queries.GetByQuery;
using Domain.Interfaces.ServiceInterfaces;

namespace API.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand createRequest, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(createRequest));

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetById([FromRoute] string id)
        => Ok(await _mediator.Send(new GetEmployeeByIdQuery(Guid.Parse(id))));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetEmployees([FromQuery] GetEmployeeQuery getEmployeeQuery, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(getEmployeeQuery));

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand updateRequest, CancellationToken cancellationToken)
    => Ok(await _mediator.Send(updateRequest));

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> DeleteEmployee([FromRoute] string id)
        => Ok(await _mediator.Send(new DeleteEmployeeCommand(Guid.Parse(id))));

    [HttpPost("upload-avatar/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UploadAvatar(IFormFile file, [FromRoute] string employeeId, CancellationToken cancellationToken)
        => Ok(await _uploadFileService.UploadAvatar(file, Guid.Parse(employeeId)));
}
