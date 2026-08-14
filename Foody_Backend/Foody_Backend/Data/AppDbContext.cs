using Foody_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foody_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set;}
    }
}