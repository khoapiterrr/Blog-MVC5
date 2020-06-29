using KQT.DataMigration;
using KQT.Entity;
using KQT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Controllers
{
    public class ContactCLientController : Controller
    {
        private readonly DataMigrationContext _context;

        public ContactCLientController()
        {
            _context = new DataMigrationContext();
        }

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

        [HttpPost]
        public JsonResult CreateContact(ContactEntity obj)
        {
            obj.Id = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString();
            _context.ContactEntities.Add(obj);
            _context.SaveChanges();
            return Json(new JsonResponse
            {
                Message = "Gửi phản hồi thành công",
                Success = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}