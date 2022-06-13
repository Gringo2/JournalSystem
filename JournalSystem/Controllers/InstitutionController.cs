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
    public class InstitutionController : ControllerBase
    {
        private readonly IRepository<Institution> _institutionRepo;
        private readonly IMapper _mapper;

        public InstitutionController(IRepository<Institution> institutionRepo, IMapper mapper)
        {
            _institutionRepo = institutionRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<InstitutionDto>>> GetAll()
        {
            IEnumerable<Institution> categories = await _institutionRepo.GetAll();
            var map = _mapper.Map<IEnumerable<InstitutionDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetInstitutionByID/{InstitutionId}")]
        public async Task<ActionResult<InstitutionDto>> GetInstitutionByID(Guid InstitutionId)
        {

            var response = await _institutionRepo.GetById(InstitutionId);
            return Ok(_mapper.Map<InstitutionDto>(response));
        }

        [HttpPost("SubmitInstitution")]
        public async Task<ActionResult<InstitutionDto>> SubmitInstitution(InstitutionDto institution)
        {
            var map = _mapper.Map<Institution>(institution);
            await _institutionRepo.Insert(map);
            return CreatedAtAction(nameof(GetInstitutionByID), new { InstitutionId = institution.InstitutionId }, institution);
        }

        [HttpPut("UpdateInstitution/{InstitutionId}")]
        public async Task<ActionResult<InstitutionDto>> PutInstitution(InstitutionDto institution)
        {
            var map = _mapper.Map<Institution>(institution);
            await _institutionRepo.Update(map);
            return Ok(_mapper.Map<InstitutionDto>(await _institutionRepo.GetById(institution.InstitutionId)));
        }

        [HttpDelete("DeleteInstitution/{cId}")]
        public async Task<ActionResult<InstitutionDto>> DeleteInstitution(Guid cId)
        {
            var deletable = await _institutionRepo.Delete(cId);
            var map = _mapper.Map<InstitutionDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
