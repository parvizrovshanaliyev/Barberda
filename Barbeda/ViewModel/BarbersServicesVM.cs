using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.ViewModel
{
    public class BarbersServicesVM
    {
        public IEnumerable<Barber> Barbers { get; set; }
        public IEnumerable<Service> Services { get; set; }
        //public ServicetoBarber ServicetoBarber { get; set; }
    }
}