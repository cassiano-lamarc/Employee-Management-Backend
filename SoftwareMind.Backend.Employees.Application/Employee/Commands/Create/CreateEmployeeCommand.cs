using MediatR;
using SoftwareMind.Backend.Employees.Domain.ObjectValue;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;

public record CreateEmployeeCommand(string firstName,
    string lastName,
    string phone,
    Guid departmentId,
    DateTime? hireDate = null,
    Address? address = null
) : IRequest<Guid>;
