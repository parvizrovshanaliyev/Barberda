using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Barbeda.Models
{
    public class BarberImage
    {

        public int Id { get; set; }

        [StringLength(350)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }


        public int BarberId { get; set; }
        public virtual Barber Barber { get; set; }
    }
}