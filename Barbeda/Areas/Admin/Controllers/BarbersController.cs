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
    public class BarbersController : Controller
    {
        private BarbedaContext _context;
        public BarbersController()
        {
            _context = new BarbedaContext();
        }
        // GET: Admin/Barbers
        public ActionResult Index()
        {
            
            return View(_context.Barbers);
        }


        #region Create
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Name,Surname,Description, Email, Tel,Photo")]Barber barber)
        {
            if (!ModelState.IsValid) return View(barber);

            if (_context.Barbers.Any(b => b.Name == barber.Name && b.Surname == barber.Surname))
            {
                ModelState.AddModelError("Name", "Bu  berber movcuddur.");
                ModelState.AddModelError("Surname", "Bu  berber movcuddur.");

                return View(barber);
            }

            if (barber.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo should be selected");

                return View(barber);
            }

            if (!barber.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Photo type is not valid");

                return View(barber);
            }
            barber.Image = barber.Photo.SavePhoto("Assets/img", "barbers");
            //if(_context.Barbers.Any(b=>b.Name == barber.Name || b.Surname == barber.Surname))
            //{
            //    if (barber.Photo != null)
            //    {
            //        if (!barber.Photo.IsImage())
            //        {
            //            ModelState.AddModelError("Photo", "Photo type is not valid");

            //            return View(barber);
            //        }

            //        barber.Image = barber.Photo.SavePhoto("Assets/img", "barbers");
            //    }
            //    else
            //    {


            //        ModelState.AddModelError("Photo", "Photo should be selected");

            //        return View(barber);
            //    }

            //    ModelState.AddModelError("Name", "Bu  berber movcuddur.");
            //    ModelState.AddModelError("Surname", "Bu  berber movcuddur.");

            //    return View(barber);
            //}
            barber.BeganWork = DateTime.Now;
            _context.Barbers.Add(barber);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion


        #region Edit
        

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var barber = _context.Barbers.Find(Id);
            if (barber == null) return HttpNotFound("Service Item yok la");
            return View(barber);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Name,Surname,Description, Photo,Email,Tel")]Barber barberI)
        {
            if (!ModelState.IsValid) return View(barberI);
            Barber barberB = _context.Barbers.Find(barberI.Id);
            if (barberI.Photo != null)
            {
                if (!barberI.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");
                    barberI.Image = barberB.Image;
                    return View(barberI);
                }
                RemoveImage("Assets/img", barberB.Image);
                barberB.Image = barberI.Photo.SavePhoto("Assets/img", "barbers");
            }
            barberB.Name = barberI.Name;
            barberB.Surname = barberI.Surname;
            barberB.Description = barberI.Description;
            barberB.Email = barberI.Email;
            barberB.Tel = barberI.Tel;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var barber = _context.Barbers.Find(Id);
            if (barber == null) return HttpNotFound("Barber Item yok la");
            return View(barber);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            var barber = _context.Barbers.Find(Id);
            RemoveImage("Assets/img", barber.Image);
            _context.BarberImages.RemoveRange(_context.BarberImages.Where(x => x.BarberId == Id));
            _context.ServicetoBarbers.RemoveRange(_context.ServicetoBarbers.Where(x => x.BarberId == Id));
            _context.SaveChanges();

            _context.Barbers.Remove(barber);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}