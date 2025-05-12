using MediatR;
using Application.DTOs;

namespace Application.Employee.Queries.GetByQuery;

public record GetEmployeeQuery (Guid? id = null, string? name = null, DateTime? dateHireStart = null, DateTime? dateHireEnd = null, Guid? departmentId = null) 
    : IRequest<List<EmployeeDTO>>;
