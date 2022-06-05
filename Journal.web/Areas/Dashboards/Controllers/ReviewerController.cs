using Microsoft.AspNetCore.Mvc;

namespace Journal.web.Areas.Dashboards.Controllers
{
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
