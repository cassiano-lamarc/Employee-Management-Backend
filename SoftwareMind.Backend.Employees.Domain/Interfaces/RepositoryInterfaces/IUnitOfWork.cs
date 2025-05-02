namespace SoftwareMind.Backend.Employees.Domain.Interfaces.RepositoryInterfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    Task<int> CommitAsync();
}
