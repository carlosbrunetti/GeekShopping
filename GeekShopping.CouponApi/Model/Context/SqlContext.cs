using GeekShopping.CouponApi.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponApi.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "PROMO_2020_10",
                DiscountAmount = 10
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "PROMO_2022_15",
                DiscountAmount = 15
            });

        }

    }
}
