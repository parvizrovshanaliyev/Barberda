using Barbeda.DAL;
using Barbeda.Extensions;
using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Barbeda.Utilities.Utilities;

namespace Barbeda.Areas.Admin.Controllers
{
    public class ServicesController : Controller
    {

        private BarbedaContext _context;
        public ServicesController()
        {
            _context = new BarbedaContext();
        }
        // GET: Admin/Services
        public ActionResult Index()
        {
            return View(_context.Services);
        }
        /// ///////////CREATE////////////////////

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Price,DataFilter,Photo")]Service service)
        {
            if (!ModelState.IsValid) return View(service);
            // ilk once bu servicin movcud olub olmadigini yoxla
            if (_context.Services.Any(s => s.Name == service.Name || s.DataFilter==service.DataFilter ))
            {
                ModelState.AddModelError("Name", "Bu servis artiq movcuddur");
                ModelState.AddModelError("DataFilter", "Bu DataFilter artiq movcuddur");

                return View(service);
            }

            //// 
            if (service.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo should be selected");

                return View(service);
            }
            /////
            if (!service.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Photo type is not valid");

                return View(service);
            }

            service.Image = service.Photo.SavePhoto("Assets/img", "services");
            //if (service.Photo != null)
            //{
            //    if (!service.Photo.IsImage())
            //    {
            //        ModelState.AddModelError("Photo", "Photo type is not valid");

            //        return View(service);
            //    }

            //    service.Image = service.Photo.SavePhoto("Assets/img", "services");
            //}
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

      
        /// ///////////////////////////////
 
        #region Edit
        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var service = _context.Services.Find(Id);
            if (service == null) return HttpNotFound("Service Item yok la");
            return View(service);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Name,Description,Price,DataFilter")]Service serviceI)
        {
            if (!ModelState.IsValid) return View(serviceI);
            Service serviceB = _context.Services.Find(serviceI.Id);
            if (serviceI.Photo != null)
            {
                if (!serviceI.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");
                    serviceI.Image = serviceB.Image;
                    return View(serviceI);
                }
                RemoveImage("Assets/img", serviceB.Image);
                serviceB.Image = serviceI.Photo.SavePhoto("Assets/img", "barbers");
            }
            serviceB.Name = serviceI.Name;
            serviceB.Description = serviceI.Description;
            serviceB.Price = serviceI.Price;
            serviceB.DataFilter = serviceI.DataFilter;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
        /// ///////////////////////////////

        #region Delete
        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var service = _context.Services.Find(Id);
            if (service == null) return HttpNotFound("Service Item yok la");
            return View(service);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            Service service = _context.Services.Find(Id);
            RemoveImage("Assets/img", service.Image);
            _context.ServicePortfolios.RemoveRange(_context.ServicePortfolios.Where(x => x.ServiceId == Id));
            _context.ServicetoBarbers.RemoveRange(_context.ServicetoBarbers.Where(x => x.ServiceId == Id));
            _context.SaveChanges();
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        /// ///////////////////////////////


    }
}