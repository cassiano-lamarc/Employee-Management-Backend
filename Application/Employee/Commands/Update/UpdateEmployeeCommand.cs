using MediatR;
using Domain.ObjectValue;

namespace Application.Employee.Commands.Update;

public record UpdateEmployeeCommand(Guid id, Guid departmentId) : IRequest<bool>;
