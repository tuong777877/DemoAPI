using DemoMyWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoMyWebAPI.Data
{
    public class CarStoreContext :DbContext
    {
        public CarStoreContext(DbContextOptions<CarStoreContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CateCar> CateCars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
