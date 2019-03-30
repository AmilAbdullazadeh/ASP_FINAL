using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ASPFinal.DAL
{
    public class CarContext : DbContext
    {

        public CarContext() : base("CarContext") { }

        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDetails>()
                .HasRequired(c => c.FuelType)
                .WithMany(c => c.CarDetails)
                .HasForeignKey(c => c.FuelTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarDetails>()
                .HasRequired(c => c.Gearbox)
                .WithMany(c => c.CarDetails)
                .HasForeignKey(c => c.GearboxId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Announcements>()
                .HasRequired(a => a.CarDetails)
                .WithMany(a => a.Announcements)
                .HasForeignKey(a => a.CardDetailsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasRequired(m => m.Marka)
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.MarkaId)
                .WillCascadeOnDelete(false);
        }
    }
}