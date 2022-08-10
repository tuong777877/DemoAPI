namespace DemoMyWebAPI.Data
{
    public class CarStoreContext : DbContext
    {
        public CarStoreContext(DbContextOptions<CarStoreContext> options) : base(options)
        {
        }

        public DbSet<RefreshToken> refreshTokens { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CateCar> CateCars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CateCustomer> CateCustomers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.Id);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(od => new { od.IdCar, od.IdOrder });

                e.HasOne(c => c.Car)
                .WithMany(c => c.orderDetails)
                .HasForeignKey(c => c.IdCar)
                .HasConstraintName("FK_OderDetail_Car");

                e.HasOne(o => o.Order)
                .WithMany(o => o.orderDetails)
                .HasForeignKey(o => o.IdOrder)
                .HasConstraintName("FK_OderDetail_Order");
            });
        }
    }
}