using FluentValidation;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Update;

public class UpdateEmployeeCommandValidator: AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(u => u.id).NotEmpty().WithMessage("Employee Id is required.");
        RuleFor(u => u.id).NotEqual(Guid.NewGuid()).WithMessage("Employee Id is required.");
        RuleFor(u => u.departmentId).NotEmpty().WithMessage("Department Id is required.");
        RuleFor(u => u.departmentId).NotEqual(Guid.NewGuid()).WithMessage("Department Id is required.");
    }
}
