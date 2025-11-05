using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public interface IFileService
{
    Task<Guid> SaveFileAsync(IFormFile file);
}