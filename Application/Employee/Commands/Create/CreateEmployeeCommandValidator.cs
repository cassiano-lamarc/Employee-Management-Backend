using FluentValidation;

namespace Application.Employee.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(c => c.firstName).NotEmpty().WithMessage("First Name is required.");
        RuleFor(c => c.phone).NotEmpty().WithMessage("Phone is required.");
        RuleFor(c => c.hireDate).NotEmpty().WithMessage("Hire date is required.");
    }
}
