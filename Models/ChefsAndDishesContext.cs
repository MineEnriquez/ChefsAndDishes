using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Models
{
    public class AppDbContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes {get;set;}
        public DbSet<Chef> Chefs {get; set;}

    }
}
