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
    public class TopicController : ControllerBase
    {
        private readonly IRepository<Topic> _topicRepo;
        private readonly IMapper _mapper;

        public TopicController(IRepository<Topic> topicRepo, IMapper mapper)
        {
            _topicRepo = topicRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetAll()
        {
            IEnumerable<Topic> categories = await _topicRepo.GetAll();
            var map = _mapper.Map<IEnumerable<TopicDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetTopicByID/{TopicId}")]
        public async Task<ActionResult<TopicDto>> GetTopicByID(Guid TopicId)
        {

            var response = await _topicRepo.GetById(TopicId);
            return Ok(_mapper.Map<TopicDto>(response));
        }

        [HttpPost("SubmitTopic")]
        public async Task<ActionResult<TopicDto>> SubmitTopic(TopicDto topic)
        {
            var map = _mapper.Map<Topic>(topic);
            await _topicRepo.Insert(map);
            return CreatedAtAction(nameof(GetTopicByID), new { TopicId = topic.TopicId }, topic);
        }

        [HttpPut("UpdateTopic/{TopicId}")]
        public async Task<ActionResult<TopicDto>> PutTopic(TopicDto topic)
        {
            var map = _mapper.Map<Topic>(topic);
            await _topicRepo.Update(map);
            return Ok(_mapper.Map<TopicDto>(await _topicRepo.GetById(topic.TopicId)));
        }

        [HttpDelete("DeleteTopic/{cId}")]
        public async Task<ActionResult<TopicDto>> DeleteTopic(Guid cId)
        {
            var deletable = await _topicRepo.Delete(cId);
            var map = _mapper.Map<TopicDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
