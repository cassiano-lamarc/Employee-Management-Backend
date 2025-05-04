using MediatR;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Domain.Entities.Employee.Create(request.firstName, request.lastName, request.phone, request.departmentId, Guid.Parse(_currentUserService.UserId!), request.hireDate, request.address);

        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.CommitAsync();

        return employee.Id;
    }
}
