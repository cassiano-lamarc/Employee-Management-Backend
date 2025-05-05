using MediatR;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Queries.GetById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Domain.Entities.Employee>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetWithIncludes(request.id);
}
