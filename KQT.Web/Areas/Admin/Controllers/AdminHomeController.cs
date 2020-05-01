using KQT.DataMigration;
using KQT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        DataMigrationContext db = new DataMigrationContext();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }
        #region News
        public ActionResult News()
        {
            List<NewsEntity> news = db.NewsEntities.ToList();
            
            return View(news);
        }
        #endregion

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
        public ActionResult EditNguoiDung(NguoiDung nguoiDung, int id ,HttpPostedFileBase fUpload )
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
        #endregion

        #region Vai trò
        public ActionResult VaiTro()
        {
            List<VaiTro> vaitro = db.VaiTros.ToList();

            return View(vaitro);
        }
        public ActionResult CreateVaiTro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVaiTro(VaiTro vaiTro)
        {
            if (ModelState.IsValid)
            {
                db.VaiTros.Add(vaiTro);
                db.SaveChanges();
                return RedirectToAction("VaiTro");
            }
            return null;
        }
        [HttpGet]
        public ActionResult EditVaiTro(int VaiTroId)
        {
            VaiTro vaitro = db.VaiTros.SingleOrDefault(x => x.Id == VaiTroId);
            return View(vaitro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVaiTro(VaiTro vaitro , int id)
        {
            VaiTro vaitroOld = db.VaiTros.Where(x => x.Id == id).First();
            if (ModelState.IsValid)
            {
                db.Entry(vaitroOld).CurrentValues.SetValues(vaitro);
                db.SaveChanges();
                return RedirectToAction("VaiTro");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetailsVaiTro(int VaiTroId)
        {
            VaiTro vaiTro = db.VaiTros.Where(x => x.Id == VaiTroId).First();
            return View(vaiTro);
        }
        public ActionResult DeleteVaiTro(int VaiTroId)
        {
            if (ModelState.IsValid)
            {
                VaiTro vaiTro = db.VaiTros.Where(x => x.Id == VaiTroId).First();
                db.VaiTros.Remove(vaiTro);
                db.SaveChanges();
                return View();
            }
            return null;
        }
        #endregion
    }
}