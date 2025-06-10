using Microsoft.EntityFrameworkCore;
using SneakerStoreAPI.Models;


    public class AppDbContext : DbContext // No need to specify the namespace explicitly
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sneaker> Sneakers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User Role Configuration (Default to "Customer")
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("Customer");

        // CartItem Relationships
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.User)
            .WithMany()
            .HasForeignKey(ci => ci.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Sneaker)
            .WithMany()
            .HasForeignKey(ci => ci.SneakerId)
            .OnDelete(DeleteBehavior.Cascade);

        // OrderItem Relationships
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Sneaker)
            .WithMany()
            .HasForeignKey(oi => oi.SneakerId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}

