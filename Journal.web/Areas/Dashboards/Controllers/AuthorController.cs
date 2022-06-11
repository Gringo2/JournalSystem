﻿using Journal.web.Models;
using Journal.web.Services;
using Journal.web.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Controllers
{   
    [Authorize( Roles = "Admin")]
    [Area("Dashboards")]
    [Route("Dashboards/Author")]
    public class AuthorController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly ITopicRequestService _topicRequstService;
        public AuthorController(IPaperRequestService paperRequestService, ITopicRequestService topicRequstService)
        {
            _paperRequestService = paperRequestService;
            _topicRequstService = topicRequstService;
        }

        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index()  {

            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            //var idtoken = await HttpContext.GetTokenAsync("id_token");

            //var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            //var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            //var claims = User.Claims.ToList();
            //var id = _idtoken.Claims.Single(x => x.Type == "sub");

            //var UserId = Guid.Parse(id.Value);
            var Paper = await _paperRequestService.GetById("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var Topics = await _topicRequstService.Getall();
            return View( new PaperViewModel
            {
                Paper = Paper,
                Topics = Topics
            });

        }

        [Route("AddPaper")]
        
        public async Task<IActionResult> AddPaper()
        {
            var getPapers = await _paperRequestService.Getall();
            var getTopics = await _topicRequstService.Getall();
            
            return View( new PaperViewModel
            {
                Topics = getTopics
            });
        }
        [Route("profile")]
        public  IActionResult Profile()
        {
            return View();

        }


        [HttpPost("AddPaper")]
        public async Task<ActionResult> AddPaper([FromForm]IFormFile files, PaperViewModel paperViewModel)
        {

            PaperDto paper = paperViewModel.Paper;
            var topicId = paperViewModel.SelectedTopic;
            //add topic to paper
            if (files.Length > 0)
            {
                // full path to file in temp location
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Papers", files.FileName);
                //we are using Temp file name just for the example. Add your own file path.

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }

            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.           
            // properties must be checked

            paper.FilePath = files.FileName;
            await _paperRequestService.Insert(paper);
            return RedirectToAction("Index");
        }
        [Route("Notifications")]
        public Task<IActionResult> GetNotifications()
        {

            return null;

        }

        
    }
}
