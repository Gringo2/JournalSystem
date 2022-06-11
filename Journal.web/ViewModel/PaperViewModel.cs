using Journal.web.Models;
using System;
using System.Collections.Generic;

namespace Journal.web.ViewModel
{
    public class PaperViewModel
    {
        public PaperDto Paper { get; set; }
        public Guid SelectedTopic { get; set; }
        public IEnumerable<PaperDto> Papers { get; set; }
        public IEnumerable<TopicDto> Topics { get; set; }
    }
}
