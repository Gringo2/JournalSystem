using Journal.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Controllers
{   
    [Authorize]
    [Area("Dashboards")]
    [Route("Dashboards/Author")]
    public class AuthorController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;

        public AuthorController(IPaperRequestService paperRequestService)
        {
            _paperRequestService = paperRequestService;
        }
       
        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index() {

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _accesstoken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);
            return View();


        }
    }
}
