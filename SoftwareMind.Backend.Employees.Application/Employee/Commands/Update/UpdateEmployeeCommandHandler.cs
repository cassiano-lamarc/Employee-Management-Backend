using MediatR;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeDB = await _unitOfWork.Employees.GetByIdAsync(request.id);
        if (employeeDB == null)
            throw new ArgumentNullException("Employee not found");

        employeeDB.UpdateDepartment(request.departmentId, Guid.Parse(_currentUserService.UserId!));
        _unitOfWork.Employees.Update(employeeDB);
        await _unitOfWork.CommitAsync();

        return true;
    }
}
