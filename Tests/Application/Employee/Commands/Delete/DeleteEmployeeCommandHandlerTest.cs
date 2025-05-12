using FluentValidation;
using FluentValidation.Results;
using Moq;
using Application.Employee.Commands.Delete;
using Domain.Exceptions;
using Domain.Interfaces.RepositoryInterfaces;
using Xunit;

namespace Tests.Application.Employee.Commands.Delete;

public class DeleteEmployeeCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly Mock<IValidator<DeleteEmployeeCommand>> _validatorMock = new();

    [Fact(DisplayName = "Should delete employee")]
    public async Task Handle_ShouldDeleteEmployee()
    {
        //Arrange
        var employeeRequestId = Guid.NewGuid();
        var employeeMock = Domain.Entities.Employee.Create("first", "last", "phone", Guid.NewGuid(), Guid.NewGuid());
        _unitOfWork.Setup(u => u.Employees.GetByIdAsync(employeeRequestId)).ReturnsAsync(employeeMock);
        _unitOfWork.Setup(u => u.Employees.Remove(employeeMock));
        var command = new DeleteEmployeeCommand(employeeRequestId);
        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());
        var handler = new DeleteEmployeeCommandHandler(_unitOfWork.Object, _validatorMock.Object);
        
        //Act
        var response = await handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.True(response);
    }

    [Fact(DisplayName = "Should handle error when deleting not found employee")]
    public async Task Handle_ShouldHandleErrorWhenDeletingNotFoundEmployee()
    {
        //Arrange
        var employeeRequestId = Guid.Empty;
        _unitOfWork.Setup(u => u.Employees.GetByIdAsync(employeeRequestId)).ReturnsAsync((Domain.Entities.Employee)null);
        var command = new DeleteEmployeeCommand(employeeRequestId);
        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());
        var handler = new DeleteEmployeeCommandHandler(_unitOfWork.Object, _validatorMock.Object);

        //Act
        var error = await Assert.ThrowsAsync<BusinessException>(() => handler.Handle(command, CancellationToken.None));

        //Assert
        Assert.Equal("Employee not found", error.Message);
    }
}
