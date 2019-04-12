using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.ViewModel
{
    public class BarberImagesVM
    {
        public IEnumerable<Barber> Barbers { get; set; }
        public BarberImage BarberImage { get; set; }
    }
}