using KQT.DataMigration;
using KQT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseAdminController
    {
        private DataMigrationContext db = new DataMigrationContext();

        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }

        #region Người dùng

        public ActionResult NguoiDung()
        {
            List<NguoiDung> user = db.NguoiDungs.ToList();
            return View(user);
        }

        public ActionResult CreateNguoiDung()
        {
            ViewBag.ListVaiTro = new SelectList(db.VaiTros.ToList(), "Id", "TenVaiTro");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNguoiDung(NguoiDung nguoiDung, HttpPostedFileBase fUpload)
        {
            if (ModelState.IsValid)
            {
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    fUpload.SaveAs(Server.MapPath("~/Content/img/User/" + fUpload.FileName));
                    nguoiDung.Avatar = fUpload.FileName;
                }
                else
                {
                    nguoiDung.Avatar = "default_user_image.png";
                }
                nguoiDung.NgayTao = DateTime.Now;
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("NguoiDung");
            }
            return null;
        }

        [HttpGet]
        public ActionResult EditNguoiDung(int NguoiDungId)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(x => x.Id == NguoiDungId);
            ViewBag.ListVaiTro = new SelectList(db.VaiTros.ToList(), "Id", "TenVaiTro");
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNguoiDung(NguoiDung nguoiDung, int id, HttpPostedFileBase fUpload)
        {
            NguoiDung nguoidungOld = db.NguoiDungs.Where(x => x.Id == id).First();
            if (ModelState.IsValid)
            {
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    fUpload.SaveAs(Server.MapPath("~/Content/img/User/" + fUpload.FileName));
                    nguoiDung.Avatar = fUpload.FileName;
                }
                db.Entry(nguoidungOld).CurrentValues.SetValues(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("NguoiDung");
            }
            return null;
        }

        [HttpGet]
        public ActionResult DetailsNguoiDung(int NguoiDungId)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(x => x.Id == NguoiDungId);
            return View(user);
        }

        public ActionResult DeleteNguoiDung(int NguoiDungId)
        {
            NguoiDung user = db.NguoiDungs.SingleOrDefault(x => x.Id == NguoiDungId);
            if (user != null)
            {
                db.NguoiDungs.Remove(user);
                db.SaveChanges();
                return RedirectToAction("NguoiDung");
            }
            return View();
        }

        #endregion Người dùng

        private Boolean CheckFile(HttpPostedFileBase fUpload, string path)
        {
            if (fUpload != null && fUpload.ContentLength > 0)
            {
                fUpload.SaveAs(Server.MapPath("~/Content/img/" + path + "/ " + fUpload.FileName));
                return true;
            }
            return false;
        }
    }
}