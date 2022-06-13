using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IRepository<Reviewer> _reviewerRepo;
        private readonly IMapper _mapper;

        public ReviewerController(IRepository<Reviewer> reviewerRepo, IMapper mapper)
        {
            _reviewerRepo = reviewerRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewerDto>>> GetAll()
        {
            IEnumerable<Reviewer> categories = await _reviewerRepo.GetAll();
            var map = _mapper.Map<IEnumerable<ReviewerDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetReviewerByID/{ReviewerId}")]
        public async Task<ActionResult<ReviewerDto>> GetReviewerByID(Guid ReviewerId)
        {

            var response = await _reviewerRepo.GetById(ReviewerId);
            return Ok(_mapper.Map<ReviewerDto>(response));
        }

        [HttpPost("SubmitReviewer")]
        public async Task<ActionResult<ReviewerDto>> SubmitReviewer(ReviewerDto reviewer)
        {
            var map = _mapper.Map<Reviewer>(reviewer);
            await _reviewerRepo.Insert(map);
            return CreatedAtAction(nameof(GetReviewerByID), new { ReviewerId = reviewer.Id }, reviewer);
        }

        [HttpPut("UpdateReviewer/{ReviewerId}")]
        public async Task<ActionResult<ReviewerDto>> PutReviewer(ReviewerDto reviewer)
        {
            var map = _mapper.Map<Reviewer>(reviewer);
            await _reviewerRepo.Update(map);
            return Ok(_mapper.Map<ReviewerDto>(await _reviewerRepo.GetById(reviewer.Id)));
        }

        [HttpDelete("DeleteReviewer/{cId}")]
        public async Task<ActionResult<ReviewerDto>> DeleteReviewer(Guid cId)
        {
            var deletable = await _reviewerRepo.Delete(cId);
            var map = _mapper.Map<ReviewerDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
