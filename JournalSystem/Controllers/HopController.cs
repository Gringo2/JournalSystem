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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HopDto>>> GetAll()
        {
            IEnumerable<Hop> hops = await _hopRepo.GetAll();
            var map = _mapper.Map<IEnumerable<HopDto>>(hops);
            return Ok(map);
        }
    }
}
