using Microsoft.EntityFrameworkCore;
using OnlineRestaurantWebAPI.DataModels;

namespace OnlineRestaurantWebAPI.DataContext

{
    public class RestaurantDataContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Server=Maheel\\SQLEXPRESS;Database=OnlineRestaurant;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.cust_ID);
            modelBuilder.Entity<Customer>().HasMany(c => c.OrderDetails).WithOne(od => od.Customer);

            modelBuilder.Entity<Shop>().HasKey(s => s.shop_ID);
            modelBuilder.Entity<Shop>().HasMany(s => s.OrderDetails).WithOne(od => od.Shop);

            modelBuilder.Entity<OrderDetails>().HasKey(od => od.order_ID);
            modelBuilder.Entity<OrderDetails>().HasOne(od => od.Shop).WithMany(s => s.OrderDetails).HasForeignKey(od => od.shop_ID);
            modelBuilder.Entity<OrderDetails>().HasOne(od => od.Customer).WithMany(c => c.OrderDetails).HasForeignKey(od => od.cust_ID);
            modelBuilder.Entity<OrderDetails>().HasOne(od => od.Food).WithMany(f => f.OrderDetails).HasForeignKey(od => od.food_ID);

            modelBuilder.Entity<Payment>().HasKey(p => p.pay_ID);
            modelBuilder.Entity<Payment>().HasOne(p => p.Customer).WithMany(c => c.Payments).HasForeignKey(p => p.cust_ID);
            modelBuilder.Entity<Payment>().HasOne(p => p.OrderDetails).WithMany(od => od.Payments).HasForeignKey(p => p.order_ID);
            modelBuilder.Entity<Payment>().HasOne(p => p.Delivery).WithMany(d => d.Payments).HasForeignKey(p => p.delivery_ID);

            modelBuilder.Entity<Menu>().HasKey(m => m.menu_ID);
            modelBuilder.Entity<Menu>().HasOne(m => m.Food).WithMany(f => f.Menus).HasForeignKey(m => m.food_ID);

            modelBuilder.Entity<Food>().HasKey(f => f.food_ID);

            modelBuilder.Entity<Delivery>().HasKey(d => d.delivery_ID);
            modelBuilder.Entity<Delivery>().HasOne(d => d.OrderDetails).WithOne(od => od.Delivery).HasForeignKey<Delivery>(d => d.order_ID);

            modelBuilder.Entity<Transaction>().HasKey(t => t.trans_ID);
            modelBuilder.Entity<Transaction>().HasOne(t => t.Customer).WithMany(c => c.Transactions).HasForeignKey(t => t.cust_ID);
            modelBuilder.Entity<Transaction>().HasOne(t => t.Shop).WithMany(c => c.Transactions).HasForeignKey(t => t.shop_ID);
            modelBuilder.Entity<Transaction>().HasOne(t => t.OrderDetails).WithMany(od => od.Transactions).HasForeignKey(t => t.order_ID);
        }
    }

   





   
}
