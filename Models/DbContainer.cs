using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlackEyesMvc.Models
{
    public class DbContainer: DbContext
    {
        public DbContainer():base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContainer, Migrations.Configuration>());
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Unit> units { get; set; }
        public DbSet<ProductUnit> productUnits { get; set; }
      
        public DbSet<Order> orders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Register> register { get; set; }
    }
}