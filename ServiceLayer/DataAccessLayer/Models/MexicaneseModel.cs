using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccessLayer.Models
{
    //using System;
    //using System.Data.Entity;
    //using System.ComponentModel.DataAnnotations.Schema;
    //using System.Linq;

    public partial class MexicaneseModel : DbContext
    {
        public MexicaneseModel() : base("name=MexicaneseModel")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CustomerInformation> CustomerInformations { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<OrderCoupon> OrderCoupons { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .Property(e => e.discountAmount)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.OrderCoupons)
                .WithRequired(e => e.Coupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.itemPrice)
                .HasPrecision(9, 2);

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.MenuItem)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Order>()
                //.HasMany(e => e.OrderCoupons)
                //.WithRequired(e => e.Order)
                //.HasForeignKey(e => e.orderId)
                //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Order>()
                //.HasMany(e => e.OrderCoupons1)
                //.WithRequired(e => e.Order1)
                //.HasForeignKey(e => e.orderId)
                //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderItems)
            //    .WithRequired(e => e.Order)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.CustomerInformation)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
