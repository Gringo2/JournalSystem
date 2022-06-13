using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class IssueController : ControllerBase
        {
            private readonly IRepository<Issue> _issueRepo;
            private readonly IMapper _mapper;

            public IssueController(IRepository<Issue> issueRepo, IMapper mapper)
            {
                _issueRepo = issueRepo;
                _mapper = mapper;
            }

            [HttpGet("GetAll")]
            public async Task<ActionResult<IEnumerable<IssueDto>>> GetAll()
            {
                IEnumerable<Issue> issues = await _issueRepo.GetAll();
                var map = _mapper.Map<IEnumerable<IssueDto>>(issues);
                return Ok(map);
            }

            [HttpGet("GetIssueByID/{Id}")]
            public async Task<ActionResult<IssueDto>> GetIssueByID(Guid Id)
            {

                var response = await _issueRepo.GetById(Id);
                return Ok(_mapper.Map<IssueDto>(response));
            }

            [HttpPost("SubmitIssue")]
            public async Task<ActionResult<IssueDto>> SubmitIssue(IssueDto issue)
            {
                var map = _mapper.Map<Issue>(issue);
                await _issueRepo.Insert(map);
                return CreatedAtAction(nameof(GetIssueByID), new { IssueId = issue.Id }, issue);
            }

            [HttpPut("UpdateIssue/{Id}")]
            public async Task<ActionResult<IssueDto>> UpdateIssue(IssueDto issue)
            {
                var map = _mapper.Map<Issue>(issue);
                await _issueRepo.Update(map);
                return Ok(_mapper.Map<IssueDto>(await _issueRepo.GetById(issue.Id)));
            }

            [HttpDelete("DeleteIssue/{cId}")]
            public async Task<ActionResult<IssueDto>> DeleteIssue(Guid cId)
            {
                var deletable = await _issueRepo.Delete(cId);
                var map = _mapper.Map<IssueDto>(deletable);

                if (deletable == null)
                {
                    return NotFound();
                }
                return map;
            }
        }
}
