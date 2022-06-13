using AutoMapper;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using JournalSystem.Entities;
using JournalSystem.Models;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepo;
        private readonly IMapper _mapper;

        public AuthorController(IRepository<Author> authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
        {
            IEnumerable<Author> categories = await _authorRepo.GetAll();
            var map = _mapper.Map<IEnumerable<AuthorDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetAuthorByID/{AuthorId}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorByID(Guid AuthorId)
        {

            var response = await _authorRepo.GetById(AuthorId);
            return Ok(_mapper.Map<AuthorDto>(response));
        }

        [HttpPost("SubmitAuthor")]
        public async Task<ActionResult<AuthorDto>> SubmitAuthor(AuthorDto author)
        {
            var map = _mapper.Map<Author>(author);
            await _authorRepo.Insert(map);
            return CreatedAtAction(nameof(GetAuthorByID), new { AuthorId = author.Id }, author);
        }

        [HttpPut("UpdateAuthor/{AuthorId}")]
        public async Task<ActionResult<AuthorDto>> PutAuthor(AuthorDto author)
        {
            var map = _mapper.Map<Author>(author);
            await _authorRepo.Update(map);
            return Ok(_mapper.Map<AuthorDto>(await _authorRepo.GetById(author.Id)));
        }

        [HttpDelete("DeleteAuthor/{cId}")]
        public async Task<ActionResult<AuthorDto>> DeleteAuthor(Guid cId)
        {
            var deletable = await _authorRepo.Delete(cId);
            var map = _mapper.Map<AuthorDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
