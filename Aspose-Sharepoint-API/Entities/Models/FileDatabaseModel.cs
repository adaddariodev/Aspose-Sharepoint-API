using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Table("FileDetails")]
    public class FileDatabaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public FileType FileType { get; set; }
    }
}
