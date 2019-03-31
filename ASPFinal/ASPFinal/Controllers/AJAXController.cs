using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.Models;
using ASPFinal.ViewModels;
using ASPFinal.DAL;

namespace ASPFinal.Controllers
{
    public class AJAXController : Controller
    {
        private readonly CarContext _context;

        public AJAXController()
        {
            _context = new CarContext();
        }

        // GET: AJAX
        public ActionResult LoadModel(int markaId)
        {
            var vm = new HomeIndexVM
            {
                models = _context.Models.Where(m => m.MarkaId == markaId).ToList()
            };

            return PartialView("_LoadModelPartial", vm);
        }
        //public ActionResult LoadMoreAnnouncements(int skip)
        //{
        //    var itemAnnoun = _context.Announcements.OrderByDescending(p => p.UpdateDate).Skip(skip).Take(1).FirstOrDefault();
        //    return PartialView("_PartialAnnouncement", itemAnnoun);
        //}
    }
}