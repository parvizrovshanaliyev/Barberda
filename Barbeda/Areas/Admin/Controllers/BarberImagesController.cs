using Barbeda.DAL;
using Barbeda.Extensions;
using Barbeda.Models;
using Barbeda.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Barbeda.Utilities.Utilities;

namespace Barbeda.Areas.Admin.Controllers
{
    public class BarberImagesController : Controller
    {
        private BarbedaContext _context;
        public BarberImagesController()
        {
            _context = new BarbedaContext();
        }
        // GET: Admin/BarberImages
        public ActionResult Index()
        {
            return View(_context.BarberImages);
        }

        public ActionResult Create()
        {
            var vm = new BarberImagesVM
            {
                Barbers = _context.Barbers

            };
            return View(vm);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Create(int BarberId, HttpPostedFileBase Photo)
        {
            if (!ModelState.IsValid) return View();

            var barber = _context.Barbers.Find(BarberId);
            if (barber == null) return HttpNotFound("Service Item yok la");
            BarberImage barberImage = new BarberImage
            {
                BarberId = BarberId
            };


            if (Photo != null)
            {
                if (!Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");

                    return View();
                }

                barberImage.Image = Photo.SavePhoto("Assets/img", "barberImages");
            }

            _context.BarberImages.Add(barberImage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        /////////////////////////////////////////
    }
}