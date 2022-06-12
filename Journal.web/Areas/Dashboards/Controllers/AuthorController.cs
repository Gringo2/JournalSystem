using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
    //[Authorize( Roles = "Admin")]
    [Area("Dashboards")]
    [Route("Dashboards/Author")]
    public class AuthorController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly ITopicRequestService _topicRequstService;
        private readonly ICommentRequestService _commentRequestService;
        private readonly IHopRequestService _hopRequestService;
        private readonly INotificationRequestService _notificationRequestService;
        private readonly TokenInjectionService _tokenInjectionService;
        public AuthorController(IPaperRequestService paperRequestService, ITopicRequestService topicRequstService,
                                ICommentRequestService commentRequestService, IHopRequestService hopRequestService,
                                INotificationRequestService notificationRequestService, TokenInjectionService tokenInjectionService)
        {
            _paperRequestService = paperRequestService;
            _topicRequstService = topicRequstService;
            _commentRequestService = commentRequestService;
            _hopRequestService = hopRequestService;
            _notificationRequestService = notificationRequestService;
            _tokenInjectionService = tokenInjectionService;
        }

        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index() {
            var Papers = await _paperRequestService.Getall();
            
            return View( new PaperViewModel
            {
                Papers = Papers
            });
        }

        [Route("PublishedPapers")]
        public Task<IActionResult> PublishedPapers()
        {
            return null;
        }
        [Route("Notifications")]
        public IActionResult Notifications()
        {
            
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
        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        



    }
}
