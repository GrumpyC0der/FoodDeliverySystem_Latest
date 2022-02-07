using FoodDeliverySystem.Shared;
using FoodDeliverySystem.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Server.Models
{
    public class FoodDeliveryDbContext:DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions options) : base(options)
        {

        }

        public FoodDeliveryDbContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<FoodStores> FoodStores { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<OrderItems> OrderItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;




        // public object Shared { get; internal set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.ToTable("userdetails");
        //        entity.Property(e => e.Userid).HasColumnName("Userid");
        //        entity.Property(e => e.Username)
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Address)
        //            .HasMaxLength(500)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Cellnumber)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Emailid)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });
        //    OnModelCreatingPartial(modelBuilder);
        //}

        //public void OnModelCreatingPartial(ModelBuilder modelBuilder)
        //{
        //    //throw new NotImplementedException();
        //}
    }
}
