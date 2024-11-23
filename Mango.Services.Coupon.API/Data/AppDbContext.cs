using Microsoft.EntityFrameworkCore;
using x=Mango.Services.Coupon.API.Models;

namespace Mango.Services.Coupon.API.Data
{
    public class CouponAppDbContext : DbContext
    {
        public CouponAppDbContext(DbContextOptions<CouponAppDbContext> options) : base(options) { }

        public DbSet<x.Coupon> Coupons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<x.Coupon>().HasData(new x.Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinimumAmount=20
            });

            modelBuilder.Entity<x.Coupon>().HasData(new x.Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinimumAmount = 40
            });
        }
    }
}
