﻿using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Models;
using Journal.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Controllers
{

    [Area("Dashboards")]
    [Route("Dashboards/Reviewer")]
    public class ReviewerController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly INotificationRequestService _notificationRequestService;
        private readonly ICommentRequestService _commentRequestService;
        private readonly IHopRequestService _hopRequestService;

        public ReviewerController(IPaperRequestService paperRequestService, INotificationRequestService notificationRequestService,
                                  ICommentRequestService commentRequestService, IHopRequestService hopRequestService)
        {
            _paperRequestService = paperRequestService;
            _commentRequestService = commentRequestService;
            _notificationRequestService = notificationRequestService;
            _hopRequestService = hopRequestService;

        }

        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var Papers = await _paperRequestService.Getall();
            return View(new PaperViewModel
            {
                Papers = Papers
            });
        }
        
        // sends Comment to user
        //can also be action only

        [Route("Comments")]
        public IActionResult Comments()
        {
            var Comment = new CommentsDto
            {

            };

             _commentRequestService.Insert(Comment);
            return View();
        }

        // no views only action

        [Route("BacktoEditor")]
        public async Task<IActionResult> BackToEditor()
        {
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);

            var Hop = new HopDto
            {
                SenderId = UserId

            };
            return View();
        }

        [Route("Notifications")]
        public IActionResult Notifications()
        {
            var notify = new NotificationDto
            {

            };

            _notificationRequestService.Insert(notify);

            return View();

        }
        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);
            
            return View();
        }

        
        
        [Route("EditDecisions")]
        public IActionResult EditDecisions()
        {
            return View();
        }
        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
