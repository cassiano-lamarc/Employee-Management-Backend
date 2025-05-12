using FluentValidation;

namespace Application.Employee.Commands.Delete;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(d => d.id).NotEmpty().WithMessage("Employee Id is required.");
        RuleFor(d => d.id).NotEqual(Guid.Empty).WithMessage("Employee Id is required.");
    }
}
