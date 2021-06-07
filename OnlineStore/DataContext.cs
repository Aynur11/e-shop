using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace OnlineStore
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SectionImage> SectionImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineStore;Integrated Security=True;Pooling=False");
        }
    }
}
