using FoodTracker.Data.Persistence.Entities.Product;
using FoodTracker.Data.Persistence.Entities.ProductTracking;
using FoodTracker.Data.Persistence.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodTracker.Data.Persistence.Context;

internal sealed class VoedingDbContext : DbContext
{
    public VoedingDbContext(DbContextOptions<VoedingDbContext> opt) : base(opt)
    {
    }

    public VoedingDbContext() : base(new DbContextOptionsBuilder().UseSqlServer("Server=Ucci-PC\\SQLEXPRESS;Database=Voeding.Store;Trusted_Connection=True;Encrypt=False").Options)
    {
    }

    public DbSet<BaseProductEntity> BaseProducts { get; set; }
    public DbSet<MeasurementUnitEntity> MeasurementUnits { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductInfoEntity> ProductInfo { get; set; }
    public DbSet<TrackedMealEntity> TrackedMeals { get; set; }
    public DbSet<UserSettingsEntity> UserSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => (ProductInfoEntity)p.ProductInfo)
            .WithOne()
            .HasForeignKey<ProductEntity>(e => e.ProductInfoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductEntity>()
            .HasMany(p => (ICollection<MeasurementUnitEntity>)p.Units)
            .WithMany();

        modelBuilder.Entity<BaseProductEntity>()
            .HasMany(p => (ICollection<ProductEntity>)p.Products);

        modelBuilder.Entity<TrackedMealEntity>()
            .HasOne(p => (ProductEntity)p.Product)
            .WithMany();

        modelBuilder.Entity<TrackedMealEntity>()
            .HasOne(p => (MeasurementUnitEntity)p.Unit)
            .WithMany();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}