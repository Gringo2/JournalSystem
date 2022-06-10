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
    public class NotificationController : ControllerBase
    {
        private readonly IRepository<Notification> _notificationRepo;
        private readonly IMapper _mapper;

        public NotificationController(IRepository<Notification> notificationRepo, IMapper mapper)
        {
            _notificationRepo = notificationRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAll()
        {
            IEnumerable<Notification> notifications = await _notificationRepo.GetAll();
            var map = _mapper.Map<IEnumerable<NotificationDto>>(notifications);
            return Ok(map);
        }

        [HttpGet("GetNotificationByID/{Id}")]
        public async Task<ActionResult<NotificationDto>> GetNotificationByID(Guid Id)
        {

            var response = await _notificationRepo.GetById(Id);
            return Ok(_mapper.Map<NotificationDto>(response));
        }

        [HttpPost("SubmitNotification")]
        public async Task<ActionResult<NotificationDto>> SubmitNotification(NotificationDto notification)
        {
            var map = _mapper.Map<Notification>(notification);
            await _notificationRepo.Insert(map);
            return CreatedAtAction(nameof(GetNotificationByID), new { NotificationId = notification.Id }, notification);
        }

        [HttpPut("UpdateNotification/{Id}")]
        public async Task<ActionResult<NotificationDto>> PutNotification(NotificationDto notification)
        {
            var map = _mapper.Map<Notification>(notification);
            await _notificationRepo.Update(map);
            return Ok(_mapper.Map<NotificationDto>(await _notificationRepo.GetById(notification.Id)));
        }

        [HttpDelete("DeleteNotification/{cId}")]
        public async Task<ActionResult<NotificationDto>> DeleteNotification(Guid cId)
        {
            var deletable = await _notificationRepo.Delete(cId);
            var map = _mapper.Map<NotificationDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
