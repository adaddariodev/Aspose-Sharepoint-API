using ASA.Domain.Enums;
using Microsoft.VisualBasic.FileIO;

namespace ASA.Domain.Models
{
    public class FileDetails
    {
        public int ID { get; set; }
        public string? FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public long Size { get; set; } //byte
        public byte[]? FileData { get; set; }
        public FileType FileType { get; set; }

    }
}
