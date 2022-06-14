using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using JournalSystem.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {
        private readonly IFileProvider fileProvider;

        public DownloadController(IFileProvider provider)
        {
            fileProvider = provider;
        }

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName == null)
            {
                return Content("File Name is Empty...");
            }

            // get the filePath

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "C:/Users/Elihu/source/repos/JournalSystems/JournalSystem/Store/Files/", fileName);

            // create a memorystream
            var memoryStream = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            // set the position to return the file from
            memoryStream.Position = 0;

            // Get the MIMEType for the File

            return File(memoryStream, "application/octet-stream" , Path.GetFileName(filePath));
        }
    }
}
