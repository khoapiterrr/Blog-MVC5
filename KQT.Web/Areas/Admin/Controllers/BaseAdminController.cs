using KQT.Web.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        //public static string strControlerCurrent = string.Empty;
        // GET: AdminBase
        /// <summary>
        /// Kiểm tra xem đã đang nhập chưa?
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = Session[ConstantData.USER_SESSION];

            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "login", Action = "Index" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}