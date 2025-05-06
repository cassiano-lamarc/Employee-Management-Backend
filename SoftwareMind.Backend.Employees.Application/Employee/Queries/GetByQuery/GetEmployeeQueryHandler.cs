using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftwareMind.Backend.Employees.Application.DTOs;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Queries.GetByQuery;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDTO>>
{
    private IMapper _mapper;
    private readonly IEmployeeRepository _repository;

    public GetEmployeeQueryHandler(
        IMapper mapper,
        IEmployeeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<EmployeeDTO>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var firstName = request.name?.Split(" ")?[0];
        var lastName = request.name?.Split(" ")?[1];

        return await _repository.GetQueryFilter(request.id, firstName, lastName, request.dateHireStart, request.dateHireEnd, request.departmentId)
            .ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
