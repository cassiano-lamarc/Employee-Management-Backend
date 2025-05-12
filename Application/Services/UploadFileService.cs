using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;

namespace Application.Services;

public class UploadFileService : IUploadFileService
{
    private readonly IUnitOfWork _unitOfWork;
    public UploadFileService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> UploadAvatar(IFormFile file, Guid employeeId)
    {
        if (file == null || file.Length == 0)
            throw new BusinessException("Invalid file.");

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "employees");
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(folderPath, fileName);
        var fileExtension = Path.GetExtension(fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        var relativeUrl = $"/images/employees/{fileName}";

        var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
        employee.UpdateAvatarUrl(relativeUrl);
        await _unitOfWork.CommitAsync();

        return true;        
    }
}
