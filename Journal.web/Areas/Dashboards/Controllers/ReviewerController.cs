using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Models;
using Journal.web.Services;
using JournalSystem.Models;
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
    [Authorize( Roles ="Reviewer")]
    [Area("Dashboards")]
    [Route("Dashboards/Reviewer")]
    public class ReviewerController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly INotificationRequestService _notificationRequestService;
        private readonly ICommentRequestService _commentRequestService;
        private readonly IHopRequestService _hopRequestService;
        private readonly IReviewerService _reviewerService;

        public ReviewerController(IPaperRequestService paperRequestService, INotificationRequestService notificationRequestService,
                                  ICommentRequestService commentRequestService, IHopRequestService hopRequestService,
                                  IReviewerService reviewerService)
        {
            _paperRequestService = paperRequestService;
            _commentRequestService = commentRequestService;
            _notificationRequestService = notificationRequestService;
            _hopRequestService = hopRequestService;
            _reviewerService = reviewerService;

        }

        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var accesstoken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accesstoken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var userid = Guid.Parse(id.Value);

            //var role = _idtoken.Claims.FirstOrDefault(r => r.Type == "roles");


            //local data store of user Id
            await _reviewerService.Insert(new ReviewerDto
            {   
                Id = userid,
                RoleId = 4,
                InstitutionId = Guid.Parse("3fa85f64-5717-4562-b3ec-2c963f66afa6"),
                FieldId = Guid.Parse("3fa85f64-5717-4562-b3ec-2c963f66afa6")

            });

            var Papers = await _paperRequestService.Getall();




            return View(new PaperViewModel
            {
                Papers = Papers
            });
        }
        
        [Route("Comments")]
        public async Task<IActionResult> Comments(Guid paperId)
        {
            var idtoken = await HttpContext.GetTokenAsync("id_token");
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);

            var getPaper = await _paperRequestService.GetById(paperId);

            return View(new CommentViewModel
            {
                Paper = getPaper

            });
        }
        [Route("PaperId")]
        [HttpPost]
        public IActionResult SelectPaper([FromForm] Guid selectedPaper)
        {
            return RedirectToAction("Comments", new { paperId = selectedPaper });
        }

        [Route("BacktoEditor")]
        public async Task BackToEditor(PaperDto Paper)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);

            var hop = new HopDto
            {   
                Id       = Guid.NewGuid(),
                SenderId = UserId,
                RecieverId = Paper.EditorId,
                StatusId = 7,   //Decision Recommended
                Notify = true,
                Created = DateTime.Now,
                PaperId = Paper.PaperId,
                NotificationId = Guid.Parse("3fa85f64-5817-4562-b3fd-2c963f66afa6")  // Decision Recommended

            };

            await _hopRequestService.Insert(hop);
            RedirectToAction();
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
