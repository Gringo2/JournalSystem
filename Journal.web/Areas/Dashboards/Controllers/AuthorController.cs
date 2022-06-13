using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Models;
using Journal.web.Services;
using JournalSystem.web.Models;
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
    [Authorize( Roles = "Author")]
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
        private readonly IAuthorRequestService _authorRequestService;
        public AuthorController(IPaperRequestService paperRequestService, ITopicRequestService topicRequstService,
                                ICommentRequestService commentRequestService, IHopRequestService hopRequestService,
                                INotificationRequestService notificationRequestService, TokenInjectionService tokenInjectionService,
                                IAuthorRequestService authorRequestService)
        {
            _paperRequestService = paperRequestService;
            _topicRequstService = topicRequstService;
            _commentRequestService = commentRequestService;
            _hopRequestService = hopRequestService;
            _notificationRequestService = notificationRequestService;
            _tokenInjectionService = tokenInjectionService;
            _authorRequestService = authorRequestService;
        }

        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index() {

            var accesstoken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accesstoken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var userid = Guid.Parse(id.Value);
            //var role = _idtoken.Claims.FirstOrDefault(r => r.Type == "roles");
            

            //local data store of user Id
            await _authorRequestService.Insert(new AuthorDto
            {
                
                Id = userid,
                RoleId = 2,
                InstitutionId = Guid.Parse("3fa85f64-5717-4562-b3ec-2c963f66afa6"),
                FieldId = Guid.Parse("3fa85f64-5717-4562-b3ec-2c963f66afa6")

            });

            var Papers = await _paperRequestService.Getall();
            

            
          
            return View( new PaperViewModel
            {
                Papers = Papers
            });
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
            var role  = _idtoken.Claims.Single(r => r.Type == "roles");
            
            var email = _idtoken.Claims.Single(e => e.Type == "email");
            var phone = _idtoken.Claims.Single(e => e.Type == "phone");
            var fname = _idtoken.Claims.Single(n => n.Type == "firstname");
            var lname = _idtoken.Claims.Single(l => l.Type == "lastname");



            return View(new ProfileViewModel
            {
                FName = fname.Value,
                LName = lname.Value,
                email = email.Value,
                Phone_number = phone.Value,
                Role  = role.Value

            });
        }
        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

    }
}
