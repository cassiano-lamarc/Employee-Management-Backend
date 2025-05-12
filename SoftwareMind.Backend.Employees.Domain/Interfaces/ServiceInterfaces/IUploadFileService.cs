using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.ServiceInterfaces;

public interface IUploadFileService
{
    Task<bool> UploadAvatar(IFormFile file, Guid employeeId);
}
 