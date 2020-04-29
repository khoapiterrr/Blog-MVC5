using KQT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var obj = new PageHeaderViewModel
            {
                IsHome = false,
                Author = "Trọng Khoa",
                CreatedDate = DateTime.UtcNow.ToString("dd/mm/yyy"),
                SubTitle = "Problems look mighty small from 150 miles up",
                Title = "Man must explore, and this is exploration at its greatest",
                Image = "post-sample-image.jpg"
            };
            return View(obj);
        }
    }
}