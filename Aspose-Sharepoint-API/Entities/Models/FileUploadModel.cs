using Entities.Enums;

namespace Entities.Models
{
    public class FileUploadModel
    {
        public IFormFile? FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
}
