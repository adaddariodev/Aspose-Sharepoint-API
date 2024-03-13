using ASA.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASA.Data.DataModels
{
    public class FileUpload
    { 
        public IFormFile? FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
}
