using KQT.DataMigration;
using KQT.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Model
{
    public class CheckPermissionAttribute : AuthorizeAttribute
    {
        public string PermissionName { get; set; }
        public ConstantCommon.Action Action;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var _context = new DataMigrationContext();
            NguoiDung objUser = null;
            objUser = HttpContext.Current.Session[ConstantData.USER_SESSION] as NguoiDung;
            if (objUser == null)
            {
                return false;
            }
            if (objUser.VaiTro != null && objUser.VaiTro.TenVaiTro == "Administrator")
            {
                return true;
            }
            //Vai trò

            int RoleId = (int)objUser.VaiTroId;
            ChucNang CNPM = null;
            try
            {
                //Lấy chức năng
                CNPM = _context.ChucNangs.FirstOrDefault(x => string.Compare(x.TenForm, PermissionName, true) == 0);
                //Kiểm tra chức năng và vai trò
                if (CNPM != null && !string.IsNullOrEmpty(RoleId + ""))
                {
                    PhanQuyen objChucNang = null;
                    objChucNang = _context.PhanQuyens.Where(p => (int)p.VaiTroId == RoleId && p.ChucNangId == CNPM.Id).First();
                    if (objChucNang != null)
                    {
                        if (CheckAction(objChucNang))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Areas/Admin/Views/login/ChuaCoQuyen.cshtml"
            };
        }

        /// <summary>
        /// Kiểm tra có quyền thêm, xóa, sửa không
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CheckAction(PhanQuyen obj)
        {
            switch (Action)
            {
                case ConstantCommon.Action.View:
                    {
                        if (obj.Xem == true)
                        {
                            return true;
                        }
                    }
                    break;

                case ConstantCommon.Action.Delete:
                    {
                        if (obj.Xoa == true)
                        {
                            return true;
                        }
                    }
                    break;

                case ConstantCommon.Action.Edit:
                    {
                        if (obj.Sua == true)
                        {
                            return true;
                        }
                    }
                    break;

                case ConstantCommon.Action.Add:
                    {
                        if (obj.Them == true)
                        {
                            return true;
                        }
                    }
                    break;

                case ConstantCommon.Action.Report:
                    {
                        if (obj.BaoCao == true)
                        {
                            return true;
                        }
                    }
                    break;

                default:
                    return false;
            }
            return false;
        }
    }
}