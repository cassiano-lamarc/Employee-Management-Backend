using FluentValidation;
using MediatR;
using Domain.Exceptions;
using Domain.Interfaces.RepositoryInterfaces;

namespace Application.Employee.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteEmployeeCommand> _validator;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteEmployeeCommand> validator)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BusinessException(string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage).ToList()));

        var employee = await _unitOfWork.Employees.GetByIdAsync(request.id);
        if (employee == null)
            throw new BusinessException("Employee not found");

        _unitOfWork.Employees.Remove(employee!);
        await _unitOfWork.CommitAsync();

        return true;
    }
}
