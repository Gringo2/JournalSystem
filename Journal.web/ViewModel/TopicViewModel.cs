using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.ViewModel
{
    public class TopicViewModel
    {
        public TopicDto Topic { get; set; }
        public Guid CategoryId { get; set; }
    }
}
