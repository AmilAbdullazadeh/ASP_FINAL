﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.Models;
using ASPFinal.ViewModels;
using ASPFinal.DAL;
using static ASPFinal.Extensions.FileExtensions;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ASPFinal.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly CarContext _context;

        public AnnouncementsController()
        {
            _context = new CarContext();
        }

        // GET: Announcements
        public ActionResult Create()
        {
            HomeIndexVM vm = new HomeIndexVM
            {
                fuelTypes = _context.FuelTypes.ToList(),
                gearboxes = _context.Gearboxes.ToList(),
                markas = _context.Markas.ToList()
            };
            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "Image")] HomeIndexVM homeIndexVM, HttpPostedFileBase Image)
        {
            //try
            //{
            //CarDetails carDetails = new CarDetails();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Image", "You do not choose a picture");
                return View(homeIndexVM);
            }

            if (Image == null)
            {
                ModelState.AddModelError("Image", "The shape of the image is incorrect. Only .jpeg, .jpg, .png, .gif are accepted");
                return View(homeIndexVM);
            }


            //Task CarDetailsWaiter = Task.Run(() =>
            //{
            //    carDetails.CarMarch = homeIndexVM.carDetail.CarMarch;
            //    carDetails.Color = homeIndexVM.carDetail.Color;
            //    carDetails.EngineCapacity = homeIndexVM.carDetail.EngineCapacity;
            //    carDetails.ShortContent = homeIndexVM.carDetail.ShortContent;
            //    carDetails.GearboxId = homeIndexVM.carDetail.GearboxId;
            //    carDetails.FuelTypeId = homeIndexVM.carDetail.FuelTypeId;
            //    carDetails.ModelId = homeIndexVM.carDetail.ModelId;
            //    carDetails.Image = SaveImage(Server.MapPath("~/Public/assets/media/components/b-goods/"), Image);

            //    _context.CarDetails.Add(carDetails);
            //});

            //_context.SaveChanges();

            //await CarDetailsWaiter;

            //_context.Announcements.Add(new Announcements
            //{
            //    CardDetailsId = carDetails.Id,
            //    CreateDate = DateTime.Now,
            //    UpdateDate = DateTime.Now,
            //    Vip = false
            //});

            //_context.SaveChanges();
            //}

            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}

            homeIndexVM.carDetail.Image = SaveImage(Server.MapPath("~/Public/assets/media/components/b-goods/"), Image);

            _context.CarDetails.Add(homeIndexVM.carDetail);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            CarDetails carDetailsDB = await _context.CarDetails.FindAsync(id);

            if (carDetailsDB == null) return HttpNotFound();

            return View(carDetailsDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CarDetails carDetails, HttpPostedFileBase NewImage)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            if (NewImage != null)
            {
                DeleteImage(Server.MapPath("~/Public/assets/media/components/b-goods/"), carDetails.Image);

                carDetails.Image = SaveImage(Server.MapPath("~/Public/assets/media/components/b-goods/"), NewImage);
            }

            //carDetails.CreateDate = DateTime.Now;

            _context.Entry(carDetails).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeletePOST(int? id)
        {
            if (id == null) return HttpNotFound();

            Announcements announcementsDB = await _context.Announcements.FindAsync(id);

            if (announcementsDB == null) return HttpNotFound();

            _context.Announcements.Remove(announcementsDB);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
