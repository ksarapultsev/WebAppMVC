using System.Data.Entity;
using WebApp3.Models;

namespace WebApp3
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(d => d.Users)
                .WithMany(s => s.Products)
                .Map(t => t.MapLeftKey("ProductId"))
                .Map(f => f.MapRightKey("UserId")
                .ToTable("ProductUsers"));
        }

    }
}