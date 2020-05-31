using HashPassword;
using KQT.DataMigration;
using KQT.Entity;
using KQT.Web.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataMigrationContext _context;

        public LoginController()
        {
            _context = new DataMigrationContext();
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            //string currenturl = AdminBaseController.strControlerCurrent;
            //ViewBag.Url = currenturl;
            HttpCookie cookie = Request.Cookies[ConstantData.USER_COOKIES];
            //Nhớ mật khẩu
            ViewBag.UserLogin = new LoginModel();
            ViewBag.UserLogin.username = string.Empty;
            ViewBag.UserLogin.password = string.Empty;
            if (cookie != null)
            {
                ViewBag.UserLogin.username = cookie[ConstantData.USERNAME_COOKIES].ToString();
                ViewBag.UserLogin.password = cookie[ConstantData.PASSWORD_COOKIES].ToString();
            }
            return View();
        }

        public ActionResult CheckLogin(string username, string pwd, string remember)
        {
            //Lưu trang hiện tại để khi đăng nhập thành công có thể đến
            //string currenturl = AdminBaseController.strControlerCurrent;
            //ViewBag.Url = currenturl;
            NguoiDung obj = getObjByUser(username);

            if (obj.Id > 0)
            {
                if (BCryptPassword.VerifyPassword(pwd, obj.MatKhau))
                { //Đăng nhập thành công
                    Session.Add(ConstantData.USER_SESSION, obj);
                    if (Convert.ToBoolean(remember))
                    {
                        HttpCookie cookie = new HttpCookie(ConstantData.USER_COOKIES);
                        cookie[ConstantData.USERNAME_COOKIES] = obj.TenDangNhap;
                        cookie[ConstantData.PASSWORD_COOKIES] = pwd;
                        cookie.Expires = DateTime.Now.AddDays(100);
                        Response.Cookies.Add(cookie);
                    }
                    return Json(new { error = false, message = "Đăng nhập thành công" });
                }
                return Json(new { error = true, message = "Mật khẩu không chính xác" });
            }
            return Json(new { error = true, message = "Tài khoản không chính xác" });
        }

        /// <summary>
        /// Hàm Lấy thông tin người dùng bằng username
        /// Author          Date            Comments
        /// KhoaLT        5/5/2019        Tạo mới
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public NguoiDung getObjByUser(string user)
        {
            try
            {
                return _context.NguoiDungs.Where(x => x.TenDangNhap.Equals(user)).First();
            }
            catch (Exception)
            {
                return new NguoiDung();
            }
        }

        public ActionResult Logout()
        {
            //AdminBaseController.strControlerCurrent = string.Empty;
            Session[ConstantData.USER_SESSION] = null;
            //Lưu nhật kí

            return RedirectToAction("Index", "login");
        }

        public JsonResult DoiMatKhau(string pwdhientai, string pwd1)
        {
            var objuser = (NguoiDung)Session[ConstantData.USER_SESSION];
            if (BCryptPassword.VerifyPassword(pwdhientai, objuser.MatKhau))
            {
                NguoiDung obj = _context.NguoiDungs.Find(objuser.Id);
                obj.MatKhau = BCryptPassword.GetHashPassword(pwd1);
                _context.SaveChanges();
                return Json(new JsonPostBack("Đổi mật khẩu thành công", true), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonPostBack("Mật khẩu hiện tại không chính xác", false), JsonRequestBehavior.AllowGet);
        }

        public ViewResult ChuaCoQuyen()
        {
            return View();
        }

        public ActionResult FogetPassword()
        {
            return View();
        }
    }
}