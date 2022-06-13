using Journal.web.Areas.Dashboards.Models.ViewModel;
using Journal.web.Models;
using Journal.web.Services;
using Journal.web.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Pages.Data
{
    public class UploadFileModel : PageModel
    {
        
        private readonly IPaperRequestService _paperRequestService;
        private readonly ITopicRequestService _topicRequestService;
        private readonly IHopRequestService _hopRequestService;
        
        public UploadFileModel(IPaperRequestService paperRequestService, ITopicRequestService topicRequestService,
                                IHopRequestService hopRequestService)
        {
            _paperRequestService = paperRequestService;
            _topicRequestService = topicRequestService;
            _hopRequestService = hopRequestService;
        }

        [BindProperty]
        public IModel Input { get; set; }
        public PaperViewModel Paper { get; set; }
        public IEnumerable<TopicDto> TopicDtos { get; set; }
        public string ReturnUrl { get; set; }
       
        public List<SelectListItem> Options { get; set; }
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
            public string SelectedTopic { get; set; }
            [Required]
            public IFormFile Upload { get; set; }




        }
        public async void OnGetAsync()
        {   
           
            TopicDtos = await _topicRequestService.Getall();
            Options = TopicDtos.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.TopicId.ToString(),
                                      Text =  a.TopicName
                                  }).ToList();
            Options.Insert(0, new SelectListItem { Value = "", Text = "SelectTopics" });
        }

        public async Task<IActionResult> OnPostAsync(string ReturnUrl = null)
        {
            // extract user id from id token 
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            var _idtoken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);

            var claims = User.Claims.ToList();
            var id = _idtoken.Claims.Single(x => x.Type == "sub");
            var UserId = Guid.Parse(id.Value);
            var Hop = new HopDto
            {
                SenderId = UserId

            };
               

            await _hopRequestService.Insert(Hop);
            
            Guid topicId = Guid.Parse(Input.SelectedTopic);
            ReturnUrl ??= Url.Content("/Dashboards/Author");
            var Paper = new PaperDto
            {
                PaperId = Guid.NewGuid(),
                Title_name = Input.Title,
                Abstract = Input.Abstract,
                FilePath = Input.Upload.FileName,
                TopicId = topicId,
                Version = 1,
                No_Pages = 1,
                HopCount = 1,
                Created = DateTime.Now,
                Published = DateTime.Now,
                Status = 1
                

            };
           
            //add topic to paper
            if (Input.Upload.Length > 0)
            {

                // full path to file in temp location
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Papers", Paper.FilePath);
                //we are using Temp file name just for the example. Add your own file pathout validation.           
                // properties must be checked
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.Upload.CopyToAsync(stream);
                }

            }

            await _paperRequestService.Insert(Paper);


            return LocalRedirect(ReturnUrl);

        }
        
    }
}
