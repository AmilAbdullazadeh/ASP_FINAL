using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.ViewModels;
using ASPFinal.Models;
using ASPFinal.DAL;

namespace ASPFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarContext _context;
        public HomeController()
        {
            _context = new CarContext();
        }

        public ActionResult Index()
        {
            HomeIndexVM vm = new HomeIndexVM
            {
                news = _context.News.OrderByDescending(a => a.CreateDate).Take(5).ToList(),
                announcements = _context.Announcements.OrderByDescending(a => a.UpdateDate).ToList(),
                markas = _context.Markas.ToList()
            };
            return View(vm);
        }

        public ActionResult CarDetails(int? id)
        {
            if (id == null) return HttpNotFound();

            Announcements announcements = _context.Announcements.Where(a => a.Id == id).FirstOrDefault();

            DetailsVM vm = new DetailsVM
            {
                Announcements = announcements,
                RelatedADS = _context.Announcements.Where(a => a.CarDetails.ModelId == announcements.CarDetails.ModelId && a.Id != announcements.Id).ToList()
            };

            if (vm == null) return HttpNotFound();

            return View(vm);
        }

        public ActionResult FullNews(int? id)
        {
            if (id == null) return HttpNotFound();

            News news = _context.News.Find(id);

            if (news == null) return HttpNotFound();

            HomeIndexVM vm = new HomeIndexVM
            {
                news = _context.News.Where(a => a.Id == news.Id)
            };

            return View(vm);
        }
    }
}