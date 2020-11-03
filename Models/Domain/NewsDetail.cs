using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class NewsDetail
    {
        public int NewsDetailID { get; set; }
        public string Content { get; set; }
        public string Nameposted { get; set; }
        public DateTime CreateDate { get; set; }
        public News News { get; set; }
        public int NewsID{ get; set; }
    }
}
