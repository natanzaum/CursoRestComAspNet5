using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    //Define a versão da Controller
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    //Faz o versionamento na rota da controller
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileBusiness _fileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }

        [HttpPost("uploadFile")]
        [Produces("application/json")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            FileDetailVO detail = await _fileBusiness.SaveFileToDisk(file);
            return new ObjectResult(detail);
        }

        [HttpGet("downloadFile/{filename}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            byte[] buffer = _fileBusiness.GetFile(fileName);

            if (buffer != null)
            {
                HttpContext.Response.ContentType = $"application/{Path.GetExtension(fileName).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }
    }
}
