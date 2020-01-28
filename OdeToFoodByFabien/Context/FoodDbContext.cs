using OdeToFoodByFabien.Models;
using Microsoft.EntityFrameworkCore;

namespace OdeToFoodByFabien.Context
{
    public class FoodDbContext : DbContext
    {

        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=FoodServer.db");
        }
    }
}

