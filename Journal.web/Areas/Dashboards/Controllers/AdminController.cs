using Journal.web.Models;
using Journal.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Controllers
{
    [Area("Dashboards")]
    [Route("Dashboards/Admin")]
    public class AdminController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;
        private readonly ITopicRequestService _topicRequestService;
        private readonly ICategoryRequestService _categoryRequestService;

        public AdminController(IPaperRequestService paperRequestService, ITopicRequestService topicRequestService, 
                ICategoryRequestService categoryRequestService)
        {
            _paperRequestService = paperRequestService;
            _topicRequestService = topicRequestService;
            _categoryRequestService = categoryRequestService;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            // total papers 
            // published Papers
            // 
            return View();
        }
        [Route("AddCategory")]
        public IActionResult AddCategory()
        {
            return View();
        }
        [Route("AddCategory")]
        [HttpPost]
        public IActionResult AddCategory(CategoryDto category) {
            

            return View();
        }
        [Route("AddTopics")]
        public IActionResult AddTopics()

        {
            return View();
        }
        [Route("AssignPaperToEditor")]
        public IActionResult AssignPaperToEditor()
        {
            return View();
        }
        [Route("AssignPaperToReviewer")]
        public IActionResult AssignPaperToReviewer()
        {
            return View();
        }
        [Route("GetEditors")]
        public IActionResult GetEditors()
        {
            return View();
        }
        [Route("GetReviewers")]
        public IActionResult GetReviewers()
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
