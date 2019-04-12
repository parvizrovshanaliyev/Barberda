using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Barbeda.Models
{
    public class Service
    {
        public Service()
        {
            ServicetoBarbers = new HashSet<ServicetoBarber>();
            ServicePortfolios = new HashSet<ServicePortfolio>();

        }
        public int Id { get; set; }


        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        [Required, StringLength(300)]
        public string Description { get; set; }

        [Required, StringLength(50)]
        public string DataFilter { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<ServicetoBarber> ServicetoBarbers { get; set; }

        public virtual ICollection<ServicePortfolio> ServicePortfolios { get; set; }

    }
}