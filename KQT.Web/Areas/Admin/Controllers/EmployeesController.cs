using KQT.DataMigration;
using KQT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataMigrationContext _context;

        public EmployeesController()
        {
            _context = new DataMigrationContext();
        }

        // GET: Admin/Employees
        public ActionResult Index()
        {
            //var data = ;
            return View(_context.NguoiDungs.ToList());
        }

        public JsonResult delete(int id)
        {
            try
            {
                var data = _context.NguoiDungs.FirstOrDefault(x => x.Id == id);
                if (data == null)
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Không tìm thấy đối tượng cần xóa."
                    }, JsonRequestBehavior.AllowGet);
                }
                _context.NguoiDungs.Remove(data);
                _context.SaveChanges();
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

        [HttpGet]
        public ActionResult EditNguoiDung(int id)
        {
            NguoiDung user = _context.NguoiDungs.SingleOrDefault(x => x.Id == id);
            ViewBag.ListVaiTro = new SelectList(_context.VaiTros.ToList(), "Id", "TenVaiTro");
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNguoiDung(NguoiDung nguoiDung, int id, HttpPostedFileBase fUpload)
        {
            NguoiDung nguoidungOld = _context.NguoiDungs.Where(x => x.Id == id).First();
            if (ModelState.IsValid)
            {
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    fUpload.SaveAs(Server.MapPath("~/Content/img/User/" + fUpload.FileName));
                    nguoiDung.Avatar = fUpload.FileName;
                }
                _context.Entry(nguoidungOld).CurrentValues.SetValues(nguoiDung);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return null;
        }

        public ActionResult Create()
        {
            ViewBag.ListVaiTro = new SelectList(_context.VaiTros.ToList(), "Id", "TenVaiTro");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NguoiDung nguoiDung, HttpPostedFileBase fUpload)
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
                _context.NguoiDungs.Add(nguoiDung);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return null;
        }
    }
}