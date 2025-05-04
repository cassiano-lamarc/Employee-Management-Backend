using Microsoft.AspNetCore.Http;

namespace SoftwareMind.Backend.Employees.Domain.Interfaces.ServiceInterfaces;

public interface IUploadFileService
{
    Task<bool> UploadAvatar(IFormFile file, Guid employeeId);
}
 