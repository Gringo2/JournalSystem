using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IRepository<Comments> _commentsRepo;
        private readonly IMapper _mapper;

        public CommentController(IRepository<Comments> commentsRepo, IMapper mapper)
        {
            _commentsRepo = commentsRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CommentsDto>>> GetAll()
        {
            IEnumerable<Comments> comments = await _commentsRepo.GetAll();
            var map = _mapper.Map<IEnumerable<CommentsDto>>(comments);
            return Ok(map);
        }

        [HttpGet("GetCommentByID/{Id}")]

        public async Task<ActionResult<CommentsDto>> GetCommentByID(Guid Id)
        {

            var response = await _commentsRepo.GetById(Id);
            return Ok(_mapper.Map<CommentsDto>(response));
        }

        [HttpPost("SubmitComments")]
        public async Task<ActionResult<CommentsDto>> SubmitComments(CommentsDto comments)
        {
            var map = _mapper.Map<Comments>(comments);
            await _commentsRepo.Insert(map);
            return CreatedAtAction(nameof(GetCommentByID), new { Id = comments.Id }, comments);
        }

        [HttpPut("UpdateComment/{Id}")]
        public async Task<ActionResult<CommentsDto>> PutComment(CommentsDto comments)
        {
            var map = _mapper.Map<Comments>(comments);
            await _commentsRepo.Update(map);
            return Ok(_mapper.Map<CommentsDto>(await _commentsRepo.GetById(comments.Id)));
        }

        [HttpDelete("DeleteComment/{cId}")]
        public async Task<ActionResult<CommentsDto>> DeleteComment(Guid cId)
        {
            var deletable = await _commentsRepo.Delete(cId);
            var map = _mapper.Map<CommentsDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
