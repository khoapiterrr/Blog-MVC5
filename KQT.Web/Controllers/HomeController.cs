using KQT.Web.Models;
using System;
using System.Web.Mvc;

namespace KQT.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var obj = new PageHeaderViewModel
            {
                IsHome = true,
                Author = "Trọng Khoa",
                CreatedDate = DateTime.UtcNow.ToString("dd/mm/yyy"),
                SubTitle = "hehehehe0",
                Title = "Cháo các bạn",
                Image = "home-bg.jpg"
            };
            return View(obj);
        }

        public ActionResult About()
        {
            var obj = new PageHeaderViewModel
            {
                IsHome = true,
                SubTitle = "This is what I do.",
                Title = "About Me",
                Image = "about-bg.jpg"
            };
            return View(obj);
        }
    }
}