using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Fluent API

        protected override void OnModelCreating(ModelBuilder model)
        {
            //Category
            model.Entity<Category>().HasKey(x => x.CategoryId);
            model.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            //Product
            model.Entity<Product>().HasKey(p => p.Id);
            model.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            model.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
            model.Entity<Product>().Property(p => p.Price).HasPrecision(12, 2);
            model.Entity<Product>().Property(p => p.ImageUrl).HasMaxLength(255).IsRequired();
            model.Entity<Category>()
                .HasMany(g => g.Products)
                .WithOne(c => c.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Povoando categorias
            model.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios"
                }

                );
        }
    }
}
