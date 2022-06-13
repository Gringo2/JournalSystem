using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IRepository<Field> _fieldRepo;
        private readonly IMapper _mapper;

        public FieldController(IRepository<Field> fieldRepo, IMapper mapper)
        {
            _fieldRepo = fieldRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldDto>>> GetAll()
        {
            IEnumerable<Field> categories = await _fieldRepo.GetAll();
            var map = _mapper.Map<IEnumerable<FieldDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetFieldByID/{FieldId}")]
        public async Task<ActionResult<FieldDto>> GetFieldByID(Guid FieldId)
        {

            var response = await _fieldRepo.GetById(FieldId);
            return Ok(_mapper.Map<FieldDto>(response));
        }

        [HttpPost("SubmitField")]
        public async Task<ActionResult<FieldDto>> SubmitField(FieldDto field)
        {
            var map = _mapper.Map<Field>(field);
            await _fieldRepo.Insert(map);
            return CreatedAtAction(nameof(GetFieldByID), new { FieldId = field.Id }, field);
        }

        [HttpPut("UpdateField/{FieldId}")]
        public async Task<ActionResult<FieldDto>> PutField(FieldDto field)
        {
            var map = _mapper.Map<Field>(field);
            await _fieldRepo.Update(map);
            return Ok(_mapper.Map<FieldDto>(await _fieldRepo.GetById(field.Id)));
        }

        [HttpDelete("DeleteField/{cId}")]
        public async Task<ActionResult<FieldDto>> DeleteField(Guid cId)
        {
            var deletable = await _fieldRepo.Delete(cId);
            var map = _mapper.Map<FieldDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}