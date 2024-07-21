using Entities.Enums;

namespace Entities.Models
{
    public class FileUploadModel
    {
        public IFormFile? FileData { get; set; }
        public FileType FileType { get; set; }
    }
}
