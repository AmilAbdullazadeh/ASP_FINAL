using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.Models;
using ASPFinal.DAL;

namespace ASPFinal.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly CarContext _context;

        public DashboardController()
        {
            _context = new CarContext();
        }

        // GET: Admin/Dashboard
        public ActionResult Index() => View(_context.Announcements);

    }
}