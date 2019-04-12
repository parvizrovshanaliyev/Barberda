using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Barbeda.Models
{
    public class Barber
    {
        public Barber()
        {

            ServicetoBarbers = new HashSet<ServicetoBarber>();
            BarberImages = new HashSet<BarberImage>();
        }
        public int Id { get; set; }


        [Required,StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {

                return $"{Name} {Surname}";
            }
        }

        [StringLength(350)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        [Required, StringLength(300)]
        public string Description { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Tel { get; set; }

        public DateTime BeganWork { get; set; }

        public virtual ICollection<ServicetoBarber> ServicetoBarbers { get; set; }
        public virtual ICollection<BarberImage> BarberImages { get; set; }


    }
}