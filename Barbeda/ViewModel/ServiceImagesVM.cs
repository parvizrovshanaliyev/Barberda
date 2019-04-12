using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.ViewModel
{
    public class ServiceImagesVM
    {
        public IEnumerable<Service> Services { get; set; }
        public ServicePortfolio ServicePortfolio { get; set; }
    }
}