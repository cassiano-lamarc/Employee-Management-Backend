using MediatR;
using SoftwareMind.Backend.Employees.Domain.Entities;

namespace SoftwareMind.Backend.Employees.Application.Departments.Queries.GetAll;

public record GetAllDepartmentQuery() : IRequest<IEnumerable<Department>>;
