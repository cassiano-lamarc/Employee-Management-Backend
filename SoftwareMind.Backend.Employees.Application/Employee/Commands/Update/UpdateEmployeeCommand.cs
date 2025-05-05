using MediatR;
using SoftwareMind.Backend.Employees.Domain.ObjectValue;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Update;

public record UpdateEmployeeCommand(Guid id, Guid departmentId) : IRequest<bool>;
