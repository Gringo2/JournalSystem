using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Journal.web.Areas.Dashboards.Controllers
{   
    [Authorize]
    [Area("Dashboards")]
    [Route("Dashboards/Reviewer")]
    public class ReviewerController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
