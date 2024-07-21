using Models.Enums;

namespace Models.Entities
{
    public class FileUploadModel
    {
        public IFormFile? FileData { get; set; }
        public FileType FileType { get; set; }
    }
}
