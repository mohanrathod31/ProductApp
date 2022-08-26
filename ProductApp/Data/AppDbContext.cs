using Microsoft.EntityFrameworkCore;
using ProductApp.Data.Models;

namespace ProductApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Article>()
        //        .HasOne(b => b.Product)
        //        .WithMany(ba => ba.Articles)
        //        .HasForeignKey(bi => bi.ProductId);

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<SizeScale> SizeScales { get; set; }
    }
}
