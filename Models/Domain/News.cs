using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class News
    {
        public int NewsID { get; set; }
        public string NewsImage { get; set; }
        public string Title { get; set; }
        public string Sub_content { get; set; }
    }
}
