using FluentValidation;
using FluentValidation.Results;
using Moq;
using Application.Employee.Commands.Update;
using Domain.Exceptions;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;
using Xunit;

namespace Tests.Application.Employee.Commands.Update;

public class UpdateEmployeeCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICurrentUserService> _currentUserService = new();
    private readonly Mock<IValidator<UpdateEmployeeCommand>> _validatorMock = new();

    [Fact(DisplayName = "Should Update Employee Department")]
    public async Task Handle_ShouldUpdateEmployee()
    {
        //Arrange
        var employeeRequestId = Guid.NewGuid();
        var command = new UpdateEmployeeCommand(employeeRequestId, Guid.NewGuid());
        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());
        var handler = new UpdateEmployeeCommandHandler(_unitOfWorkMock.Object, _currentUserService.Object, _validatorMock.Object);

        var employeeMock = Domain.Entities.Employee.Create("fist", "last", "phone", Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow);
        _unitOfWorkMock.Setup(u => u.Employees.GetByIdAsync(employeeRequestId)).ReturnsAsync(employeeMock);
        _currentUserService.Setup(c => c.UserId).Returns(Guid.NewGuid().ToString());

        //Act
        var response = await handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.True(response);
    }

    [Fact(DisplayName = "Should handle Business Exception")]
    public async Task Handle_BussinessException()
    {
        //Arrange
        var employeeRequestId = Guid.NewGuid();
        var command = new UpdateEmployeeCommand(employeeRequestId, Guid.NewGuid());
        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());
        var handler = new UpdateEmployeeCommandHandler(_unitOfWorkMock.Object, _currentUserService.Object, _validatorMock.Object);

        var employeeMock = Domain.Entities.Employee.Create("fist", "last", "phone", Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow);
        _unitOfWorkMock.Setup(u => u.Employees.GetByIdAsync(Guid.Empty)).ReturnsAsync(employeeMock);
        _currentUserService.Setup(c => c.UserId).Returns(Guid.NewGuid().ToString());

        //Act
        var exception = await Assert.ThrowsAsync<BusinessException>(() => handler.Handle(command, CancellationToken.None));

        //Assert
        Assert.Equal("Employee not found", exception.Message);
    }
}
