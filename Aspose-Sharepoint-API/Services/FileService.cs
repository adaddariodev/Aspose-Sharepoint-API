using Entities.Models;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Services
{
    internal class FileService : IFileService
    {
        private readonly AsaDbContext _context;

        public FileService(AsaDbContext context)
        {
            _context = context;
        }

        public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        {
            try
            {
                var fileDB = new FileDatabaseModel()
                {
                    ID = 0,
                    FileName = fileData.FileName,
                    FileType = fileType,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDB.FileData = stream.ToArray();
                }

                var result = _context.FileDetails.Add(fileDB);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostMultiFileAsync(List<FileUploadModel> uploadedFilesList)
        {
            try
            {
                foreach (FileUploadModel file in uploadedFilesList)
                {
                    if (file.FileData is null)
                        throw new InvalidOperationException();

                    var fileDB = new FileDatabaseModel()
                    {
                        ID = 0,
                        FileName = file.FileData.FileName,
                        FileType = file.FileType
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileData.CopyTo(stream);
                        fileDB.FileData = stream.ToArray();
                    }

                    var result = _context.FileDetails.Add(fileDB);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = _context.FileDetails.Where(x => x.ID == Id).FirstOrDefaultAsync();

                var content = new MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded", file.Result.FileName);
                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}