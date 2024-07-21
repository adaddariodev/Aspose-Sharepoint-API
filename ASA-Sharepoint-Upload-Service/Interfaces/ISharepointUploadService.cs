using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASA_Sharepoint_Upload_Service.Interfaces
{
    public interface ISharepointUploadService
    {
        public Task UploadFileToFolder();
    }
}
