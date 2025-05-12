using MediatR;
using Domain.Entities;

namespace Application.Departments.Queries.GetAll;

public record GetAllDepartmentQuery() : IRequest<IEnumerable<Department>>;
