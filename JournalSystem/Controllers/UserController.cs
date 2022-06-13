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
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            IEnumerable<User> categories = await _userRepo.GetAll();
            var map = _mapper.Map<IEnumerable<UserDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetUserByID/{UserId}")]
        public async Task<ActionResult<UserDto>> GetUserByID(Guid UserId)
        {

            var response = await _userRepo.GetById(UserId);
            return Ok(_mapper.Map<UserDto>(response));
        }

        [HttpPost("SubmitUser")]
        public async Task<ActionResult<UserDto>> SubmitUser(UserDto user)
        {
            var map = _mapper.Map<User>(user);
            await _userRepo.Insert(map);
            return CreatedAtAction(nameof(GetUserByID), new { UserId = user.UserId }, user);
        }

        [HttpPut("UpdateUser/{UserId}")]
        public async Task<ActionResult<UserDto>> PutUser(UserDto user)
        {
            var map = _mapper.Map<User>(user);
            await _userRepo.Update(map);
            return Ok(_mapper.Map<UserDto>(await _userRepo.GetById(user.UserId)));
        }

        [HttpDelete("DeleteUser/{cId}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid cId)
        {
            var deletable = await _userRepo.Delete(cId);
            var map = _mapper.Map<UserDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }

        [HttpPost("AddPaperUser")]
        public void AddPaperUser(UserDto obj, PaperDto ob)
        {
            var map = _mapper.Map<User>(obj);
            var map2 = _mapper.Map<Paper>(ob);
            _userRepo.AddPaperUser(map, map2);
            CreatedAtAction(nameof(GetUserByID), new { UserId = obj.UserId }, obj);
        }
    }
}
