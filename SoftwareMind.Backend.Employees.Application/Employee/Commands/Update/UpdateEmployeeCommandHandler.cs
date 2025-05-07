using FluentValidation;
using MediatR;
using SoftwareMind.Backend.Employees.Domain.Exceptions;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IValidator<UpdateEmployeeCommand> _validator;

    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IValidator<UpdateEmployeeCommand> validator)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BusinessException(string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage).ToList()));

        var employeeDB = await _unitOfWork.Employees.GetByIdAsync(request.id);
        if (employeeDB == null)
            throw new BusinessException("Employee not found");

        employeeDB.UpdateDepartment(request.departmentId, Guid.Parse(_currentUserService.UserId!));
        _unitOfWork.Employees.Update(employeeDB);
        await _unitOfWork.CommitAsync();

        return true;
    }
}
