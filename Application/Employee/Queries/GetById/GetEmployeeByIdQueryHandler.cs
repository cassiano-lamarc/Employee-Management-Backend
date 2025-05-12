using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Application.DTOs;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Queries.GetById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _repository;

    public GetEmployeeByIdQueryHandler(
        IMapper mapper,
        IEmployeeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetQueryById(request.id).ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

}
