using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Areas.Dashboards.Models.ViewModel
{
    public class CommentViewModel
    {
        public CommentsDto Comment { get; set; }
        public Guid PaperId { get; set; }
        public String SenderRole { get; set; }
    }
}
