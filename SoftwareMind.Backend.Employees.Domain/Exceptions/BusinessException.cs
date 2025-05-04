namespace SoftwareMind.Backend.Employees.Domain.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base (message)
    {
    }
}
