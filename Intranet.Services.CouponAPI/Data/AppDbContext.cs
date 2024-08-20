using Intranet.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.CouponId).HasColumnType("serial");
                entity.Property(e => e.CouponCode).HasColumnType("text");
                entity.Property(e => e.DiscountAmount).HasColumnType("int64");
                entity.Property(e => e.MinAmount).HasColumnType("int64");
            });
        }
    }
}