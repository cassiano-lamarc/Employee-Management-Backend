using MediatR;
using Application.DTOs;
using Domain.Entities;

namespace Application.Employee.Queries.GetById;

public record GetEmployeeByIdQuery(Guid id): IRequest<EmployeeDTO>;
