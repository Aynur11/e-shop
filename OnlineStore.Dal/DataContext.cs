using Microsoft.EntityFrameworkCore;
using OnlineStore.Dal.Models;

namespace OnlineStore.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SectionImage> SectionImage { get; set; }
    }
}