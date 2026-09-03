using Foody_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foody_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantPendingUpdate> RestaurantsPendingUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // علاقة Owner بالمطعم
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Owner)
                .WithOne(u => u.Restaurant)
                .HasForeignKey<Restaurant>(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقة Restaurant بالـ PendingUpdate
            modelBuilder.Entity<RestaurantPendingUpdate>()
                .HasOne(p => p.Restaurant)
                .WithOne(r => r.PendingUpdate)
                .HasForeignKey<RestaurantPendingUpdate>(p => p.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
        new User
        {
            Id = 927,
            FullName = "Admin",
            Email = "admin@foody.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@1234"),
            Gender = "Male",
            Role = "Admin",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        }
    );


        }



    }
}