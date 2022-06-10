using Journal.web.Models;
using Journal.web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Controllers
{
    [Authorize]
    [Area("Dashboards")]
    [Route("Dashboards/Editor")]
    public class EditorController : Controller
    {
        private readonly IPaperRequestService _paperRequestService;

        public EditorController(IPaperRequestService paperRequestService)
        {
            _paperRequestService = paperRequestService;

        }
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetPapers()
        {
            var papers = await _paperRequestService.Getall();
            return View(new PaperViewModel
            {
                Papers = papers
            });

        }

        public Task<IActionResult> GetNotifications()
        {

            return null;

        }

       


    }
}
