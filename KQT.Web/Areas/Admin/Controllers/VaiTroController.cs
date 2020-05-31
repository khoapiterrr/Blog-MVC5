using KQT.DataMigration;
using KQT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class VaiTroController : Controller
    {
        private DataMigrationContext db = new DataMigrationContext();

        #region Vai trò

        public ActionResult Index()
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
                return RedirectToAction("Index");
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
        public ActionResult EditVaiTro(VaiTro vaitro, int id)
        {
            VaiTro vaitroOld = db.VaiTros.Where(x => x.Id == id).First();
            if (ModelState.IsValid)
            {
                db.Entry(vaitroOld).CurrentValues.SetValues(vaitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DetailsVaiTro(int VaiTroId)
        {
            VaiTro vaiTro = db.VaiTros.Where(x => x.Id == VaiTroId).First();
            return View(vaiTro);
        }

        public JsonResult DeleteVaiTro(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = db.VaiTros.FirstOrDefault(x => x.Id == id);
                    if (data == null)
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "Không tìm thấy đối tượng cần xóa."
                        }, JsonRequestBehavior.AllowGet);
                    }
                    db.VaiTros.Remove(data);
                    db.SaveChanges();
                    return Json(new
                    {
                        Success = true,
                        Message = "Xóa thành công kích thước này."
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Không thể xóa đối tượng này. Vì sẽ ảnh hưởng đến dữ liệu khác." + ex.Message
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return null;
        }

        #endregion Vai trò
    }
}