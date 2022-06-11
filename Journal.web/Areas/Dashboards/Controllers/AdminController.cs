using Journal.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Journal.web.Areas.Dashboards.Controllers
{
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
        public IActionResult Index()
        {
            // total papers 
            // published Papers
            // 
            return View();
        }

        public IActionResult AddCategories() {
            return View();
        }
        public IActionResult AddTopics()
        {
            return View();
        }
        public IActionResult AssignPaperToEditor()
        {
            return View();
        }
        public IActionResult AssignPaperToReviewer()
        {
            return View();
        }
        public IActionResult GetEditors()
        {
            return View();
        }
        public IActionResult GetReviewers()
        {
            return View();
        }
    }
}
