using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KQT.Web.Models
{
    public class PageHeaderViewModel
    {
        public bool IsHome { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string CreatedDate { get; set; }
        public string Image { get; set; }
    }
}