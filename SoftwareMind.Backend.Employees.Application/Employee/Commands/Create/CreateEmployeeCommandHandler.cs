using FluentValidation;
using MediatR;
using Domain.Exceptions;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;

namespace Application.Employee.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IValidator<CreateEmployeeCommand> _validator;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, 
        IValidator<CreateEmployeeCommand> validator,
        ICurrentUserService currentUserService)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)  
            throw new BusinessException(string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage).ToList()));

        var employee = Domain.Entities.Employee.Create(request.firstName, request.lastName, request.phone, request.departmentId, Guid.Parse(_currentUserService.UserId!), request.hireDate, request.address);

        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.CommitAsync();

        return employee.Id;
    }
}
