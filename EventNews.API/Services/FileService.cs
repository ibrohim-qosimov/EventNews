using System;
using System.IO;
using System.Threading.Tasks;
using EventNews.API.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class FileService : IFileService
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        private const string UploadFolder = "uploads";

        public FileService(IApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Guid> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            string uploadPath = Path.Combine(_env.WebRootPath, UploadFolder);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var extension = Path.GetExtension(file.FileName);
            var fileId = Guid.NewGuid();
            var fileName = $"{fileId}{extension}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Faylni saqlaymiz
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // URL yaratamiz (masalan: https://localhost:5001/uploads/xxx.png)
            var baseUrl = $"{_env.ApplicationName}"; // bu joyda app base url bo‘lmaydi, controllerda to‘g‘ri hosil qilamiz
            var relativeUrl = $"/{UploadFolder}/{fileName}";

            // Ma’lumotni DB ga yozamiz
            var entity = new FileEntity
            {
                Id = fileId,
                FileName = fileName,
                Extension = extension,
                Url = relativeUrl
            };

            _context.Files.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }