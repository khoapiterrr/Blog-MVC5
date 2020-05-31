using KQT.DataMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class ChucNangController : BaseAdminController
    {
        private readonly DataMigrationContext _context;

        public ChucNangController()
        {
            _context = new DataMigrationContext();
        }

        // GET: Admin/ChucNang
        public ActionResult Index()
        {
            return View(_context.ChucNangs.ToList());
        }
    }
}