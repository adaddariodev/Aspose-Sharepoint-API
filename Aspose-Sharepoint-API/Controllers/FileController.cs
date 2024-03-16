using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _uploadService;

        public FileController(IFileService uploadService)
        {
            _uploadService = uploadService;
        }

        /// <summary>
        /// Single File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel uploadedFile)
        {
            if (uploadedFile == null || uploadedFile.FileData == null)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.PostFileAsync(uploadedFile.FileData, uploadedFile.FileType);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Multiple File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> uploadedFilesList)
        {
            if (uploadedFilesList == null || uploadedFilesList.Count == 0)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.PostMultiFileAsync(uploadedFilesList);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.DownloadFileById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
