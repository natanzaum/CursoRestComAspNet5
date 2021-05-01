using Microsoft.AspNetCore.Http;
using RestWithASPNET5.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Business.Implementations
{
    public class FileBusiness : IFileBusiness
    {

        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusiness(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;
            return File.ReadAllBytes(filePath);
        }

        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file)
        {
            throw new NotImplementedException();
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower() == ".pdf" ||
                fileType.ToLower() == ".jpg" ||
                fileType.ToLower() == ".png" ||
                fileType.ToLower() == ".jpeg")
            {
                var docName = Path.GetFileName(file.FileName);

                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetail.DocName = docName;
                    fileDetail.DocType = fileType;
                    fileDetail.DocURL = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return fileDetail;
        }
    }
}
