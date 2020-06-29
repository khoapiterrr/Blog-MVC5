using KQT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            var obj = new PageHeaderViewModel
            {
                IsHome = true,
                Author = "Trọng Khoa",
                CreatedDate = DateTime.UtcNow.ToString("dd/mm/yyy"),
                SubTitle = "TIN TỨC MỚI",
                Title = " Chào mừng đến với trang tin tức",
                Image = "home-bg.jpg"
            };
            //ViewBag.Data = "hehehehe";
            return View(obj);
        }
    }
}