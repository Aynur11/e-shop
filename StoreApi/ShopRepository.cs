using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Dal;
using OnlineStore.Dal.Models;

namespace OnlineStore.Api
{
    public class ShopRepository : IShopRepository
    {
        private bool disposed;
        private readonly DataContext context;

        public List<Section> Sections => context.Sections
            .Include(p => p.Products)
            .ThenInclude(i => i.Image)
            .Include(i => i.Image).ToList();

        public List<Product> Products => context.Products
            .Include(i => i.Image)
            .Include(s => s.Section).ToList();

        public List<ProductImage> ProductImages => context.ProductImages.ToList();

        public ShopRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add(Section section)
        {
            context.Sections.Add(section);
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Remove(Section section)
        {
            context.Sections.Remove(section);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
