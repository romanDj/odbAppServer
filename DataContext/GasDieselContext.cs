using gasDiesel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace gasDiesel.DataContext
{
    public class GasDieselContext : DbContext
    {
        public GasDieselContext() : base("gasDiesel.Properties.Settings.appDb")
        {
        }

        public DbSet<LiveMetric> LiveMetrics { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}