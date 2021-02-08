using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case_2.Models
{
    public class IssueViewModel
    {
        public int number { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public string comments_url { get; set; }
    }
}
