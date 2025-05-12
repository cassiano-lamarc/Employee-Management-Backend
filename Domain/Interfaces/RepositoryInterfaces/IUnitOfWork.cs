namespace Domain.Interfaces.RepositoryInterfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    Task<int> CommitAsync();
}
