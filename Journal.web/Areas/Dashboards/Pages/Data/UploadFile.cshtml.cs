using Journal.web.Models;
using Journal.web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Journal.web.Areas.Dashboards.Pages.Data
{
    public class UploadFileModel : PageModel
    {
        public IEnumerable<TopicDto> TopicDtos { get; set; }
        private readonly IPaperRequestService _paperRequestService;
        private readonly ITopicRequestService _topicRequestService;

        public UploadFileModel(IPaperRequestService paperRequestService, ITopicRequestService topicRequestService)
        {
            _paperRequestService = paperRequestService;
            _topicRequestService = topicRequestService;
        }

        [BindProperty]
        public IModel Input { get; set; }
        public PaperViewModel Paper { get; set; }
        public string ReturnUrl { get; set; }


        public class IModel
        {
            [Required]
            [StringLength(100)]
            [Display(Name = "Paper Title")]
            public string Title { get; set; }

            [Required]
            [StringLength(100)]
            [Display(Name = "Abstract")]
            public string Abstract { get; set; }

            [Required]
            [StringLength(100)]
            [Display(Name = "Select Topic")]
            public string selectedTopic { get; set; }

            [Required]

            public IFormFile Upload { get; set; }




        }
        public async void OnGetAsync()
        {
            TopicDtos = await _topicRequestService.Getall();
        }

        public async void OnPostAsync(PaperViewModel Model)
        {

            Model.Paper = new PaperDto
            {
                Title_name = Input.Title,
                Abstract = Input.Abstract,
                FilePath = Input.Upload.FileName

            };
            var topicId = Paper.SelectedTopic;
            //add topic to paper
            if (Input.Upload.Length > 0)
            {
                // full path to file in temp location
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Papers", Model.Paper.FilePath);
                //we are using Temp file name just for the example. Add your own file pathout validation.           
                // properties must be checked

            }
            await _paperRequestService.Insert(Model.Paper);


        }
        
    }
}
