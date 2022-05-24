
using System.Collections.Generic;

namespace Journal.web.Models
{
    public class PaperViewModel
    {
        public PaperDto Paper { get; set; }
        public IEnumerable<PaperDto> Papers { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
