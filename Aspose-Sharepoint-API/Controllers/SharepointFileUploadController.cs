using ASA_Sharepoint_Upload_Service;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharepointFileUploadController : ControllerBase
    {
        private readonly ISharepointUploadService _sharepointUploadService;

        public SharepointFileUploadController(ISharepointUploadService sharepointUploadService)
        {
            _sharepointUploadService = sharepointUploadService;
        }

        ///<summary>
        ///Single file upload to Sharepoint
        ///</summary>
        [HttpPost("PostSingleFileSharepoint")]
        public async Task<ActionResult> PostSingleFileToSharepoint([FromForm] FileUploadModel uploadedFileSP)
        {
            if (uploadedFileSP == null || uploadedFileSP.FileData == null)
                return BadRequest();

            try
            {
                await _sharepointUploadService.UploadFileToFolder();
                return Ok();    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
