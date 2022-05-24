using AutoMapper;
using Journal.web.Models;
using Journal.web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{

      public class PaperUpload : Controller
    {
        private readonly IPaperStoreService _paperstoreservice;
        private readonly IMapper _mapper;

        public PaperUpload(PaperStoreService paperStoreService  ,IMapper mapper)
        {
            _paperstoreservice = paperStoreService;
            _mapper = mapper;
        }
        public  IActionResult AddPaper()
        {

            //var paper = await  _paperRepo.GetAll();
            return View(new PaperViewModel
            {   //pass items to be listed or to choose from
                

            }); 

        }

        [HttpPost]
        public async Task<ActionResult> AddPaper(IFormFile files, PaperViewModel paperviewmodel)
        {

            PaperDto paper = _mapper.Map<PaperDto>( paperviewmodel.Paper);

            //long size = files.Length;
           

           // var filePaths = new List<string>();

            if (files.Length > 0)
            {
                // full path to file in temp location
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Papers", files.FileName);
                //we are using Temp file name just for the example. Add your own file path.

                using var stream = new FileStream(filePath, FileMode.Create);
                await files.CopyToAsync(stream);

            }

           
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.           
            // properties must be checked

           
            paper.File_path = files.FileName;
            await _paperstoreservice.AddPaper(paper);
            
            return RedirectToAction("ProductSaved");
        }
    }

}
