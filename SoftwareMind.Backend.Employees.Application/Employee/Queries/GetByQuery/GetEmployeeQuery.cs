using MediatR;
using SoftwareMind.Backend.Employees.Application.DTOs;

namespace SoftwareMind.Backend.Employees.Application.Employee.Queries.GetByQuery;

public record GetEmployeeQuery (Guid? id = null, string? name = null, DateTime? dateHireStart = null, DateTime? dateHireEnd = null, Guid? departmentId = null) 
    : IRequest<List<EmployeeDTO>>;
