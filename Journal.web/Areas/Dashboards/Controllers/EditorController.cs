using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Models;
using Journal.web.Services;
using Journal.web.ViewModel;
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
    [Route("Dashboards/Editor")]
    public class EditorController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly INotificationRequestService _notificationRequestService;
        private readonly ICommentRequestService _commentRequestService;
        private readonly IHopRequestService _hopRequestService;

        public EditorController(IPaperRequestService paperRequestService, INotificationRequestService notificationRequestService,
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
        //[Route("Papers")]
        //public async Task<IActionResult> Papers()
        //{
        //    return View();

        //}
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

        //sends comment to an author 
        [Route("Comments")]
        public IActionResult Comments(PaperDto paper)
        {
            var Comment = new CommentsDto
            {

            };

            _commentRequestService.Insert(Comment);

            return View();
        }
        [Route("ForwardToReviewer")]
        public async Task<IActionResult> ForwardToReviewer(PaperDto Paper)
        {
          
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);

            //required attributes to generate hop SenderId, User ID PaperId
            

            

            //var hop = _hopRequestService.Insert();
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
