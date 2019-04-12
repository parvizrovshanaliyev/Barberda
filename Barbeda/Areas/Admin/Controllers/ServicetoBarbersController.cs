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
    public class ServicetoBarbersController : Controller
    {
        private BarbedaContext _context;
        public ServicetoBarbersController()
        {
            _context = new BarbedaContext();
        }
        // GET: Admin/ServicetoBarbers
        public ActionResult Index()
        {
            return View(_context.ServicetoBarbers);
        }

        public ActionResult Create()
        {
            var vm = new BarbersServicesVM
            {
                Barbers = _context.Barbers,
                Services = _context.Services
            };
            return View(vm);
        }


        [ValidateAntiForgeryToken,HttpPost]
        public ActionResult Create(int ServiceId,int BarberId)
        {
           //var ServiceI = _context.Services.Find(ServiceId);
           //var BarberI = _context.Services.Find(BarberId);
            ServicetoBarber servicetoBarber = new ServicetoBarber
            {
                ServiceId = ServiceId,
                BarberId = BarberId
            };

            _context.ServicetoBarbers.Add(servicetoBarber);
            _context.SaveChanges();
            return RedirectToAction ("Index");
        }




        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var serviceTobarber = _context.ServicetoBarbers.Find(Id);
            ViewBag.barberId = serviceTobarber.BarberId;
            ViewBag.ServiceId = serviceTobarber.ServiceId;
            var vm = new BarbersServicesVM {

               
                Barbers = _context.Barbers,
                Services = _context.Services
            };
          
            if (serviceTobarber == null) return HttpNotFound("Service Item yok la");
            return View(vm);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int ServiceId, int BarberId,ServicetoBarber servicetoBarberI)
        {
            //if (!ModelState.IsValid) return View(servicetoBarber);
            ServicetoBarber servicetoBarberB = _context.ServicetoBarbers.Find(servicetoBarberI.Id);
            servicetoBarberB.ServiceId = ServiceId;
            servicetoBarberB.BarberId = BarberId;


            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}