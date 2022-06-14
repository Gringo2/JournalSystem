using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Models;
using Journal.web.Services;
using Journal.web.ViewModel;
using JournalSystem.web.Models;
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
    [Authorize( Roles ="Editor")]
    [Area("Dashboards")]
    [Route("Dashboards/Editor")]
    public class EditorController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly INotificationRequestService _notificationRequestService;
        private readonly ICommentRequestService _commentRequestService;
        private readonly IHopRequestService _hopRequestService;
        private readonly IEditorService _editorService;

        public EditorController(IPaperRequestService paperRequestService, INotificationRequestService notificationRequestService,
                                  ICommentRequestService commentRequestService, IHopRequestService hopRequestService,
                                  IEditorService editorService)
        {
            _paperRequestService = paperRequestService;
            _commentRequestService = commentRequestService;
            _notificationRequestService = notificationRequestService;
            _hopRequestService = hopRequestService;
            _editorService = editorService;

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
            await _editorService.Insert(new EditorDto
            {

                Id = userid,
                RoleId = 3,
                InstitutionId = Guid.Parse("3fa85f64-5717-4562-b3ec-2c963f66afa6"),
                FieldId = Guid.Parse("3fa85f64-5717-4562-b3ec-2c963f66afa6")

            });

            var Papers = await _paperRequestService.Getall();




            return View(new PaperViewModel
            {
                Papers = Papers
            });
        }

        [Route("ForwardToReviewer")]
        public async Task ForwardToReviewer(Guid Id)
        {

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);

            var Paper = await _paperRequestService.GetById(Id);


            var hop = new HopDto
            {
                SenderId = UserId,
                RecieverId = Paper.ReviewerId,
                StatusId = 2,   ////sent for review
                Notify = true,
                Created = DateTime.Now,
                PaperId = Paper.PaperId,
                NotificationId = Guid.Parse("3fa85f64-5817-4562-b3fc-2c963f66afa6") //// review process started

            };

             await  _hopRequestService.Insert(hop);
             RedirectToAction();
        }
        [Route("BackToReviewer")]
        public async Task backtoAuthor(PaperDto Paper)
        {
            
            var idtoken = await HttpContext.GetTokenAsync("id_token");
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);

            var hop = new HopDto
            {   
                Id  = Guid.NewGuid(),
                SenderId = UserId,
                RecieverId = Paper.AuthorId,
                StatusId = 6,       //Decision Made
                Notify = true,
                Created = DateTime.Now,
                PaperId = Paper.PaperId,    
                NotificationId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c023f66afa6") // DecisionMade
                
            };

            await _hopRequestService.Insert(hop);
            RedirectToAction();
        }

        [Route("Comments")]
        public async Task<IActionResult> Comments(Guid paperId)
        {
            var idtoken = await HttpContext.GetTokenAsync("id_token");
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);
            // failed to retreive paper
            var getPaper = await _paperRequestService.GetById(paperId);
            
            return View( new CommentViewModel
            {   
                Paper = getPaper
              
            });
        }
        [Route("Comments")]
        [HttpPost]
        public async Task Comments()
        {




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
