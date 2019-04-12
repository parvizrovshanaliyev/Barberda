using Barbeda.DAL;
using Barbeda.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Barbeda.Controllers
{
    public class HomeController : Controller
    {
        private readonly BarbedaContext _context;
        public HomeController()
        {
            _context = new BarbedaContext();
        }
        public ActionResult Index()
        {
            var vm = new HomeVM()
            {
                Sliders = _context.Sliders,
                Services = _context.Services,
                Barbers = _context.Barbers.Include(b => b.ServicetoBarbers).Include(b => b.BarberImages)
            };
            return View(vm);
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}