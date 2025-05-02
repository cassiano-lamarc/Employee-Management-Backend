using MediatR;
using SoftwareMind.Backend.Employees.Domain.Entities;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Departments.Queries.GetAll;

public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IEnumerable<Department>>
{
    private readonly IDepartmentRepository _repository;

    public GetAllDepartmentQueryHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllAsync();
}
