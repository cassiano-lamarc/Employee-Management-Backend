using MediatR;
using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Application.Employee.Queries.GetById;

public record GetEmployeeByIdQuery(Guid id): IRequest<Domain.Entities.Employee>;
