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
    public class EditorController : ControllerBase
    {
        private readonly IRepository<Editor> _editorRepo;
        private readonly IMapper _mapper;

        public EditorController(IRepository<Editor> editorRepo, IMapper mapper)
        {
            _editorRepo = editorRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EditorDto>>> GetAll()
        {
            IEnumerable<Editor> categories = await _editorRepo.GetAll();
            var map = _mapper.Map<IEnumerable<EditorDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetEditorByID/{EditorId}")]
        public async Task<ActionResult<EditorDto>> GetEditorByID(Guid EditorId)
        {

            var response = await _editorRepo.GetById(EditorId);
            return Ok(_mapper.Map<EditorDto>(response));
        }

        [HttpPost("SubmitEditor")]
        public async Task<ActionResult<EditorDto>> SubmitEditor(EditorDto editor)
        {
            var map = _mapper.Map<Editor>(editor);
            await _editorRepo.Insert(map);
            return CreatedAtAction(nameof(GetEditorByID), new { EditorId = editor.Id }, editor);
        }

        [HttpPut("UpdateEditor/{EditorId}")]
        public async Task<ActionResult<EditorDto>> PutEditor(EditorDto editor)
        {
            var map = _mapper.Map<Editor>(editor);
            await _editorRepo.Update(map);
            return Ok(_mapper.Map<EditorDto>(await _editorRepo.GetById(editor.Id)));
        }

        [HttpDelete("DeleteEditor/{cId}")]
        public async Task<ActionResult<EditorDto>> DeleteEditor(Guid cId)
        {
            var deletable = await _editorRepo.Delete(cId);
            var map = _mapper.Map<EditorDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
