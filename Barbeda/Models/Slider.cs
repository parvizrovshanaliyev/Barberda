using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Barbeda.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [Required , StringLength(100)]
        public string TitleOne { get; set; }


        [Required , StringLength(100)]
        public string TitleTwo { get; set; }

        public DateTime? UpdateAt { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}