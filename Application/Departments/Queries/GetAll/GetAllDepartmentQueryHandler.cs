using MediatR;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;

namespace Application.Departments.Queries.GetAll;

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
