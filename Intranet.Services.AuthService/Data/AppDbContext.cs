using Intranet.Services.AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Services.AuthService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasColumnType("text");
                entity.Property(e => e.LastName).HasColumnType("text");
                entity.Property(e => e.Email).HasColumnType("text");
                entity.Property(e => e.UserName).HasColumnType("text");
                entity.Property(e => e.Password).HasColumnType("text");
                entity.Property(e => e.CreatedAt).HasColumnType("timestamp");
            });
        }
    }
}
