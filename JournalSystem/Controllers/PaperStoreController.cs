using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PaperStoreController : ControllerBase
    {
        private readonly IRepository<Paper> _paperRepo;
        private readonly IMapper _mapper;

        public PaperStoreController(IRepository<Paper> paperRepo, IMapper mapper)
        {
            _paperRepo = paperRepo;
            _mapper = mapper;
        }
        //public IActionResult Index()
        //{
            
        //    IEnumerable<Paper> papers =  _paperRepo.GetAll();
        //    var map =  _mapper.Map<List<PaperDto>>(papers);
        //    return View(new PaperViewModel
        //    {
        //        papers = map
        //    });
        //}
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PaperDto>>> GetAll()
        {
            IEnumerable<Paper> papers = await _paperRepo.GetAll();
            var map = _mapper.Map<List<PaperDto>>(papers);
            return Ok(map);
        }

        [HttpGet("GetPaperByID/{paperId}")]

        public async Task<ActionResult<PaperDto>> GetPaperByID(Guid paperId)
        {

            var response = await _paperRepo.GetById(paperId);
            return  Ok(_mapper.Map<PaperDto>(response));
        }
        [HttpGet("GetPaperByTopic/{TopicId}")]
        //public async Task<ActionResult<PaperDto>> GetPaperByTopic(Guid TopicId) {

            
        //    return Ok();
        //}
        [HttpPost("SubmitPaper")]
        public async Task<ActionResult<PaperDto>> SubmitPaper(Paper paper)
        {
            await _paperRepo.Insert(paper);
            return CreatedAtAction(nameof(GetPaperByID), new { PaperId = paper.PaperId }, paper);
        }


        [HttpPut("UpdatePaper/{pId}")]
        public async Task<ActionResult<PaperDto>> PutPaper(Paper paper)
        {
            var pId = paper.PaperId;
            await _paperRepo.Update(paper);
            return Ok(_mapper.Map<PaperDto>(await _paperRepo.GetById(pId)));
        }

        [HttpDelete("DeletePaper/{pId}")]
        public async Task<ActionResult<PaperDto>> DeletePaper(Guid pId)
        {
            var deletable = await _paperRepo.Delete(pId);
            var map = _mapper.Map<PaperDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }

    }
}
