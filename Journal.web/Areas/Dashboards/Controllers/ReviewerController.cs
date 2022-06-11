using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public Task<IActionResult> GetNotifications()
        {

            return null;

        }

        public IActionResult SendComments()
        {
            return View();
        }

        public IActionResult GenerateHop()
        {
            return View();
        }

        public IActionResult EditDecisions()
        {
            return View();
        }
    }
}
