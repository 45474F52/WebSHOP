using Microsoft.EntityFrameworkCore;

namespace WebShopAPI.Models.Data
{
    public class ShopDataContext : DbContext
    {
        public ShopDataContext() { }
        public ShopDataContext(DbContextOptions<ShopDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .IsUnicode()
                .IsRequired(false);
            modelBuilder.Entity<Product>()
                .Property(p => p.Manufacturer)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(256);
            modelBuilder.Entity<Product>()
                .Property(p => p.Image)
                .IsUnicode()
                .IsRequired(false)
                .HasMaxLength(256);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(10, 4);
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<ProductCategory>()
                .Property(pc => pc.Name)
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(pc => pc.Name)
                .IsUnique();
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
