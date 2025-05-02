using MediatR;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Domain.Entities.Employee.Create(request.firstName, request.lastName, request.phone, request.departmentId, request.hireDate, request.address);

        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.CommitAsync();

        return employee.Id;
    }
}
