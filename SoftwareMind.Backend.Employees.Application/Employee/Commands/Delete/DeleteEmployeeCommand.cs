using MediatR;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Delete;

public record DeleteEmployeeCommand(Guid id) : IRequest<bool>;
