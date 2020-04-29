using KQT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var obj = new PageHeaderViewModel
            {
                IsHome = true,
                Author = "Trọng Khoa",
                CreatedDate = DateTime.UtcNow.ToString("dd/mm/yyy"),
                SubTitle = "Have questions? I have answers.",
                Title = "Contact Me",
                Image = "contact-bg.jpg"
            };
            return View(obj);
        }
    }
}