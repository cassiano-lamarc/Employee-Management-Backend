using MediatR;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Queries.GetByQuery;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<Domain.Entities.Employee>>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeeQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Entities.Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var firstName = request.name?.Split(" ")?[0];
        var lastName = request.name?.Split(" ")?[1];

        var employesResponse = await _repository.GetByFilter(request.id, firstName, lastName, request.dateHireStart, request.dateHireEnd, request.departmentId);

        return employesResponse;
    }
}
