using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.ViewModel
{
    public class RelatedBarberVM
    {
        public Barber Barber { get; set; }
        public IEnumerable<Barber> Barbers { get; set; }
    }
}