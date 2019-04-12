using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Barber> Barbers { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}