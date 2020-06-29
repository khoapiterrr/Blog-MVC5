using KQT.DataMigration;
using KQT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly DataMigrationContext _context;

        public ArticleController()
        {
            _context = new DataMigrationContext();
        }

        // GET: News
        public ActionResult Index(string id)
        {
            var data = _context.NewsEntities.Find(id);
            if (data == null)
                return RedirectToAction("Index", "Home");
            var obj = new PageHeaderViewModel
            {
                IsHome = false,
                Author = "Trọng Khoa",
                CreatedDate = DateTime.UtcNow.ToString("dd/mm/yyy"),
                SubTitle = data.NewTitle,
                Title = data.NewTitleSale,
                Image = data.ImageHead,
                NewsDetail = data
            };
            //Tăng view người xem

            ++data.ViewCount;
            _context.SaveChanges();
            return View(obj);
        }

        public JsonResult GetNews(int? page)
        {
            var pageNumber = page ?? 1;
            var lst = _context.NewsEntities.OrderBy(x => x.CreatedDate)
                        .Select(x => new NewsViewModel
                        {
                            DateCreated = x.CreatedDate.Value,
                            Id = x.Id,
                            Title = x.NewTitle,
                            TitleDecs = x.NewTitleSale
                        })
                        .Skip((pageNumber - 1) * 4)
                        .Take(4).ToList();
            if (lst.Count > 0)
            {
                return Json(new JsonResponse { Success = true, Message = lst }, JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonResponse { Success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}