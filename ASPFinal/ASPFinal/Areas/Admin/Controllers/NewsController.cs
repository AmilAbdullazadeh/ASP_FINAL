using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASPFinal.DAL;
using ASPFinal.Models;
using static ASPFinal.Extensions.FileExtensions;

namespace ASPFinal.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private readonly CarContext _context;

        public NewsController()
        {
            _context = new CarContext();
        }

        // GET: Admin/News
        public ActionResult Index() => View(_context.News);

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "Image")] News news, HttpPostedFileBase Image)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Image", "You do not choose a picture");
                return View(news);
            }
            if (Image == null)
            {
                ModelState.AddModelError("Image", "The shape of the image is incorrect. Only .jpeg, .jpg, .png, .gif are accepted");
                return View(news);
            }

            news.Image = SaveImage(Server.MapPath("~/Areas/Admin/Public/assets/img/"), Image);
            news.CreateDate = DateTime.Now;

            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "News");
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            News newsDB = await _context.News.FindAsync(id);

            if (newsDB == null) return HttpNotFound();

            return View(newsDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePOST(int id)
        {
            News newsDB = await _context.News.FindAsync(id);

            if (DeleteImage(Server.MapPath("~/Areas/Admin/Public/assets/img/"), newsDB.Image))
            {
                _context.News.Remove(newsDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            News newsDB = await _context.News.FindAsync(id);

            if (newsDB == null) return HttpNotFound();

            return View(newsDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(News news, HttpPostedFileBase NewImage)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            if (NewImage != null)
            {
                DeleteImage(Server.MapPath("~/Areas/Admin/Public/assets/img/"), news.Image);

                news.Image = SaveImage(Server.MapPath("~/Areas/Admin/Public/assets/img/"), NewImage);
            }

            news.CreateDate = DateTime.Now;
            _context.Entry(news).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}