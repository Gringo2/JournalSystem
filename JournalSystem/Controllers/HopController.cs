using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopController : ControllerBase
    {
        private readonly IRepository<Hop> _hopRepo;
        private readonly IMapper _mapper;

        public HopController(IRepository<Hop> hopRepo, IMapper mapper)
        {
            _hopRepo = hopRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<HopDto>>> GetAll()
        {
            IEnumerable<Hop> hops = await _hopRepo.GetAll();
            var map = _mapper.Map<IEnumerable<HopDto>>(hops);
            return Ok(map);
        }

        [HttpGet("GetHopByID/{Id}")]
        public async Task<ActionResult<HopDto>> GetHopByID(Guid Id)
        {

            var response = await _hopRepo.GetById(Id);
            return Ok(_mapper.Map<HopDto>(response));
        }

        [HttpPost("SubmitHop")]
        public async Task<ActionResult<HopDto>> SubmitHop(HopDto hop)
        {
            var map = _mapper.Map<Hop>(hop);
            await _hopRepo.Insert(map);
            return CreatedAtAction(nameof(GetHopByID), new { HopId = hop.Id }, hop);
        }

        [HttpPut("UpdateHop/{Id}")]
        public async Task<ActionResult<HopDto>> UpdateHop(HopDto hop)
        {
            var map = _mapper.Map<Hop>(hop);
            await _hopRepo.Update(map);
            return Ok(_mapper.Map<HopDto>(await _hopRepo.GetById(hop.Id)));
        }

        [HttpDelete("DeleteHop/{cId}")]
        public async Task<ActionResult<HopDto>> DeleteHop(Guid cId)
        {
            var deletable = await _hopRepo.Delete(cId);
            var map = _mapper.Map<HopDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
