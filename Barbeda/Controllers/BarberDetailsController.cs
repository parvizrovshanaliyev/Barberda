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
using System.Data.Entity;


namespace Barbeda.Controllers
{
    public class BarberDetailsController : Controller
    {
        private BarbedaContext _context;
        public BarberDetailsController()
        {
            _context = new BarbedaContext();
        }
        // GET: BarberDetails
        public ActionResult Index(int? Id)
        {
            if (Id == null) return HttpNotFound("Id gelmir la");
            var barber = _context.Barbers.Find(Id);
            if (barber == null) return HttpNotFound("Service Item yok la");

            var serviciIdList = new List<int>();
            foreach (var id in barber.ServicetoBarbers)
            {
                serviciIdList.Add(id.ServiceId);
            }

            var serviceToBarbers = new List<ServicetoBarber>();
            foreach (var id in serviciIdList)
            {
                serviceToBarbers.AddRange(_context.ServicetoBarbers.Where(sb => sb.ServiceId == id).ToList());
            }

            var filteredBarbers = new List<Barber>();
            foreach (var sb in serviceToBarbers)
            {
                filteredBarbers.AddRange(_context.Barbers.Where(b => b.Id == sb.BarberId && b.Id != barber.Id));
            }

            var vm = new RelatedBarberVM
            {
                Barber = barber,
                Barbers = filteredBarbers.ToList()
            };


            return View(vm);
        }
    }
}