using System;

namespace Journal.web.Areas.Dashboards.Models.ViewModel
{
    public class PaperTable
    {
        public string Paper_title { get; set; }
        public string Topic { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
