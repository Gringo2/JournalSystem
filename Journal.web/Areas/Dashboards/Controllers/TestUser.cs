using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Journal.web.Areas.Dashboards.Controllers
{   
    [Authorize]
    [Area("Dashboards")]
    [Route("Dashboards/dashboard")]
    public class TestUser : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
