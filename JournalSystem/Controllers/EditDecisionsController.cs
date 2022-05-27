using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditDecisionsController : ControllerBase
    {
        private readonly IRepository<EditDecisions> _editDecisionsRepo;
        private readonly IMapper _mapper;

        public EditDecisionsController(IRepository<EditDecisions> editDecisionsRepo, IMapper mapper)
        {
            _editDecisionsRepo = editDecisionsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditDecisionsDto>>> GetAll()
        {
            IEnumerable<EditDecisions> categories = await _editDecisionsRepo.GetAll();
            var map = _mapper.Map<IEnumerable<EditDecisionsDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetEditDecisionsByID/{Id}")]
        public async Task<ActionResult<EditDecisionsDto>> GetEditDecisionsByID(Guid Id)
        {

            var response = await _editDecisionsRepo.GetById(Id);
            return Ok(_mapper.Map<EditDecisionsDto>(response));
        }

        [HttpPost("SubmitEditDecisions")]
        public async Task<ActionResult<EditDecisionsDto>> SubmitEditDecisions(EditDecisionsDto editDecisions)
        {
            var map = _mapper.Map<EditDecisions>(editDecisions);
            await _editDecisionsRepo.Insert(map);
            return CreatedAtAction(nameof(GetEditDecisionsByID), new { Id = editDecisions.Id }, editDecisions);
        }

        [HttpPut("UpdateEditDecisions/{Id}")]
        public async Task<ActionResult<EditDecisionsDto>> PutEditDecisions(EditDecisionsDto editDecisions)
        {
            var map = _mapper.Map<EditDecisions>(editDecisions);
            await _editDecisionsRepo.Update(map);
            return Ok(_mapper.Map<EditDecisionsDto>(await _editDecisionsRepo.GetById(editDecisions.Id)));
        }

        [HttpDelete("DeleteEditDecisions/{Id}")]
        public async Task<ActionResult<EditDecisionsDto>> DeleteEditDecisions(Guid Id)
        {
            var deletable = await _editDecisionsRepo.Delete(Id);
            var map = _mapper.Map<EditDecisionsDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
