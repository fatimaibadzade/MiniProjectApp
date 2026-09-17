using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entity.Entities;
using System.Collections.Generic;

namespace RestaurantApp.DataAccess.Context;

public class AppDbContext : DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=PLUTO11\\SQLEXPRESS;" +
            "Initial Catalog=RestaurantDb;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Order>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<OrderItem>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.MenuItem)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.MenuItemId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId);

        modelBuilder.Entity<MenuItem>()
            .HasIndex(x => x.Name)
            .IsUnique();
    }
}
