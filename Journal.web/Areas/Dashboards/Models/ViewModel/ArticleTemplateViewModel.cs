using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.ViewModel
{
    public class ArticleTemplateViewModel
    {
        public ArticleTemplateDto ArticleTemplate { get; set; }
        public Guid PaperId { get; set; }
    }
}
