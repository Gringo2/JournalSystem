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
    public class StatusController : Controller
    {
        private readonly IRepository<Status> _statusRepo;
        private readonly IMapper _mapper;

        public StatusController(IRepository<Status> statusRepo, IMapper mapper)
        {
            _statusRepo = statusRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetAll()
        {
            IEnumerable<Status> statuses = await _statusRepo.GetAll();
            var map = _mapper.Map<IEnumerable<StatusDto>>(statuses);
            return Ok(map);
        }
    }
}
