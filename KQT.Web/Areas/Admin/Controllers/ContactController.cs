using KQT.DataMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KQT.Web.Areas.Admin.Controllers
{
    public class ContactController : BaseAdminController
    {
        private readonly DataMigrationContext _context;

        public ContactController()
        {
            _context = new DataMigrationContext();
        }

        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View(_context.ContactEntities.ToList());
        }
    }
}