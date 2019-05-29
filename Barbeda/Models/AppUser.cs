using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barbeda.Models
{
    public class AppUser:IdentityUser
    {
          public string Name { get; set; }

          public string Surname { get; set; }

    }

    public class AppRole : IdentityRole
    {
        public string Description { get; set; }


        public AppRole()
        {

        }

        public AppRole(string roleName,string description):base(roleName)
        {
            this.Description = description;
        }

    }

    public class Register
    {

    }
}