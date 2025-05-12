using MediatR;
using Domain.ObjectValue;

namespace Application.Employee.Commands.Create;

public record CreateEmployeeCommand(string firstName,
    string lastName,
    string phone,
    Guid departmentId,
    DateTime? hireDate = null,
    Address? address = null
) : IRequest<Guid>;
