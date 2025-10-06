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
        /*modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("Customer");*/

        // CartItem Relationships
        modelBuilder.Entity<Sneaker>().HasData(
        new Sneaker { Id = 13, Name = "Retro Cement 3", Brand = "Jordan", Price = 300, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/011502/1.jpg?w=1920" },
        new Sneaker { Id = 14, Name = "Air Jordan 1", Brand = "Jordan", Price = 300, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/307016/1.jpg?w=1920" },
        new Sneaker { Id = 15, Name = "Nike Dunk Low", Brand = "Nike", Price = 120, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/253215/1.jpg?w=1920" },
        new Sneaker { Id = 16, Name = "Yeezy Boost 350", Brand = "Adidas",  Price = 200, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/368573/1.jpg?w=1920" },
        new Sneaker { Id = 17, Name = "New Balance 550", Brand = "New Balance",  Price = 110, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/371711/1.jpg?w=1920" },
        new Sneaker { Id = 18, Name = "Adidas Samba OG", Brand = "Adidas", Price = 90, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/460574/1.jpg?w=1920" },
        new Sneaker { Id = 19, Name = "Puma RS-X", Brand = "Puma", Price = 100, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/397161/1.jpg?w=1920" },
        new Sneaker { Id = 20, Name = "Converse Chuck 70", Brand = "Converse", Price = 75, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/301688/1.jpg?w=1920" },
        new Sneaker { Id = 21, Name = "Reebok Club C 85", Brand = "Reebok", Price = 85, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/363222/1.jpg?w=1920" },
        new Sneaker { Id = 22, Name = "Asics Gel-Lyte III", Brand = "Asics", Price = 95, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/389891/1.jpg?w=1920" },
        new Sneaker { Id = 23, Name = "Vans Old Skool", Brand = "Vans", Price = 70, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/350502/1.jpg?w=1920" },
        new Sneaker { Id = 24, Name = "New Balance 2002R", Brand = "New Balance", Price = 160, ImageUrl = "https://cdn.flightclub.com/TEMPLATE/350162/1.jpg?w=1920" }
   
     
    );

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

