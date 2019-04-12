using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.Models
{
    public class ServicetoBarber
    {
        public int Id { get; set; }

        public int BarberId { get; set; }
        public int ServiceId { get; set; }

        public virtual Barber Barber { get; set; }
        public virtual Service Service { get; set; }

    }
}