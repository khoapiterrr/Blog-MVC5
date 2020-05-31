using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KQT.Web.Models
{
    public class NewsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TitleDecs { get; set; }
        public DateTime DateCreated { get; set; }
    }
}