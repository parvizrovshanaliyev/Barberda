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
    public class ServicePortfoliosController : Controller
    {
        private BarbedaContext _context;
        public ServicePortfoliosController()
        {
            _context = new BarbedaContext();
        }
        // GET: Admin/ServicePortfolios
        public ActionResult Index()
        {
            return View(_context.ServicePortfolios);
        }


        public ActionResult Create()
        {
            var vm = new ServiceImagesVM
            {
                Services=_context.Services

            };
            return View(vm);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Create(int ServiceId,HttpPostedFileBase Photo )
        {
            if (!ModelState.IsValid) return View();
 
            var service = _context.Services.Find(ServiceId);
            if (service == null) return HttpNotFound("Service Item yok la");
            ServicePortfolio servicePortfolio = new ServicePortfolio
            {
                ServiceId = ServiceId
            };


            if (Photo != null)
            {
                if (!Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");

                    return View();
                }
               
                servicePortfolio.Image =Photo.SavePhoto("Assets/img", "servicePortfolios");
            }

            _context.ServicePortfolios.Add(servicePortfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        /////////////////////////////////////////
        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var servicePortfolio = _context.ServicePortfolios.Find(Id);
            if (servicePortfolio == null) return HttpNotFound("ServicePortfolio fiyasko");
            ViewBag.ServiceId = servicePortfolio.ServiceId;
            ViewBag.Image = servicePortfolio.Image;
            var vm = new ServiceImagesVM
            {


               
                Services = _context.Services
            };

            
            return View(vm);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int ServiceId, HttpPostedFileBase Photo,ServicePortfolio servicePortfolio)
        {
            if (!ModelState.IsValid) return View(servicePortfolio);

            ServicePortfolio servicePortfolioBase = _context.ServicePortfolios.Find(servicePortfolio.Id);
            //var service = _context.Services.Find(ServiceId);
            //if (service == null) return HttpNotFound("Service Item yok la");

            servicePortfolioBase.ServiceId = ServiceId;


            if (Photo != null)
            {
                if (!Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo type is not valid");
                    servicePortfolio.Image = servicePortfolioBase.Image;
                    return View(servicePortfolio);
                }
                RemoveImage("Assets/img/", servicePortfolioBase.Image);
                servicePortfolioBase.Image = Photo.SavePhoto("Assets/img", "servicePortfolios");
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var servicePortfolio = _context.ServicePortfolios.Find(Id);
            if (servicePortfolio == null) return HttpNotFound("ServicePortfolio fiyasko");
            return View(servicePortfolio);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            var servicePortfolio = _context.ServicePortfolios.Find(Id);
            RemoveImage("Assets/img", servicePortfolio.Image);
            //_context.ServicePortfolios.RemoveRange(_context.ServicePortfolios.Where(x => x.ServiceId == Id));
            //_context.ServicetoBarbers.RemoveRange(_context.ServicetoBarbers.Where(x => x.ServiceId == Id));
            _context.SaveChanges();
            _context.ServicePortfolios.Remove(servicePortfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}