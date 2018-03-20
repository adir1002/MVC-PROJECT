using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectN.Models;
using System.Data.Entity.Infrastructure;

namespace ProjectN.Dal
{
    public class DataLayer : DbContext
    {
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataLayer>(null);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entrance>().ToTable("Entrancestbl");
            modelBuilder.Entity<Product>().ToTable("tblProducts");
            modelBuilder.Entity<Purchase>().ToTable("tblPurchases");
            modelBuilder.Entity<Customer>().ToTable("tblAdmins");

            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        

    }
}