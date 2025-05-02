using MediatR;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

namespace SoftwareMind.Backend.Employees.Application.Employee.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.GetByFilter(request.id);
        if (employee == null || employee.Count == 0)
            new ArgumentNullException("Employee not found");

        _unitOfWork.Employees.Remove(employee?.FirstOrDefault()!);
        await _unitOfWork.CommitAsync();

        return true;
    }
}
