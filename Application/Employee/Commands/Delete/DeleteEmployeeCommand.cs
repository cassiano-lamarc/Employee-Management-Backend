using MediatR;

namespace Application.Employee.Commands.Delete;

public record DeleteEmployeeCommand(Guid id) : IRequest<bool>;
