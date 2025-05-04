using Moq;
using SoftwareMind.Backend.Employees.Application.Employee.Commands.Create;
using SoftwareMind.Backend.Employees.Domain.Exceptions;
using SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;
using SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;
using Xunit;

namespace SoftwareMind.Backend.Employees.Tests.Application.Employee.Commands.Create;

public class CreateEmployeerCommandHandlerTest
{
    private readonly Mock<IEmployeeRepository> _repositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICurrentUserService> _currentServiceMock = new();
    private readonly Mock<IEmployeeRepository> _employeeRepository = new();

    [Theory]
    [InlineData("Name", "SubName", "11223344")]
    [InlineData("Inline Name", "SurName", "11223344")]
    [InlineData("Fluminense", "Soccer", "1902-2023")]
    public async Task Handle_ShouldCreateEmployee(string firstName, string lastName, string phone)
    {
        //arrange
        var command = new CreateEmployeeCommand(firstName, lastName, phone, Guid.NewGuid(), DateTime.UtcNow, null);
        _currentServiceMock.Setup(c => c.UserId).Returns(Guid.NewGuid().ToString());
        _unitOfWorkMock.Setup(u => u.Employees).Returns(_employeeRepository.Object);
        
        var handler = new CreateEmployeeCommandHandler(_unitOfWorkMock.Object, _currentServiceMock.Object);

        //act
        var newId = await handler.Handle(command, CancellationToken.None);

        //assert
        Assert.NotEqual(Guid.NewGuid(), newId);
    }

    [Fact(DisplayName = "Should give error when name is empty")]
    public async Task Given_Name_Empty_When_Try_Create_Then_Handle_Error()
    {
        //arrange
        var command = new CreateEmployeeCommand(" ", "notEmpty", "123", Guid.NewGuid());
        _currentServiceMock.Setup(c => c.UserId).Returns(Guid.NewGuid().ToString());
        _unitOfWorkMock.Setup(u => u.Employees).Returns(_employeeRepository.Object);

        var handler = new CreateEmployeeCommandHandler(_unitOfWorkMock.Object, _currentServiceMock.Object);

        //act
        var exception = await Assert.ThrowsAsync<BusinessException>(() => handler.Handle(command, CancellationToken.None));

        //assert
        Assert.Equal("First name is required", exception.Message);
    }
}