using DemoMyWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoMyWebAPI.Data
{
    public class CarStoreContext :DbContext
    {
        public CarStoreContext(DbContextOptions<CarStoreContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
