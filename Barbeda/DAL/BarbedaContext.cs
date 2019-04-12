using Barbeda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Barbeda.DAL
{
    public class BarbedaContext:DbContext
    {
        public BarbedaContext():base("ConnStr")
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BarberImage> BarberImages { get; set; }
        public DbSet<ServicePortfolio> ServicePortfolios { get; set; }
        public DbSet<ServicetoBarber> ServicetoBarbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}