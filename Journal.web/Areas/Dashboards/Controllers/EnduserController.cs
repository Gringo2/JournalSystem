using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Journal.web.Areas.Dashboards.Controllers
{
    [Authorize]
    [Area("Dashboards")]
    [Route("Dashboards/Enduser")]
    public class EnduserController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
