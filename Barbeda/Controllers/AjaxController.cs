using Barbeda.DAL;
using Barbeda.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barbeda.Controllers
{
    public class AjaxController : Controller
    {
        private readonly BarbedaContext _context;
        public AjaxController()
        {
            _context = new BarbedaContext();
        }
        // GET: Ajax
        //public ActionResult BarberDetail(int id)
        //{
        //    var modelb = _context.Barbers.Where(b => b.Id == id);
        //    return PartialView("_BarberDetails", modelb);
        //}


        public ActionResult BarberDetail()
        {
            
            return PartialView("_BarberDetails");
        }
    }
}