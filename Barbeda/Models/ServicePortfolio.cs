using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Barbeda.Models
{
    public class ServicePortfolio
    {

        public int Id { get; set; }

        [StringLength(350)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }


        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

    }
}