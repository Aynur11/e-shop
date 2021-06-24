using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Models
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
            .Include(i => i.Image).ToList();

        public List<ProductImage> ProductImages => context.ProductImages.ToList();

        public ShopRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add(Section section)
        {
            try
            {
                context.Sections.Add(section);
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при добавлении раздела: {e.Message}");
            }
        }

        public void Add(Product product)
        {
            try
            {
                context.Products.Add(product);
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при добавлении продукта: {e.Message}");
            }
        }

        public void Remove(Section section)
        {
            try
            {
                context.Sections.Remove(section);
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при удалении раздела: {e.Message}");
            }
        }

        public void Remove(Product product)
        {
            try
            {
                context.Products.Remove(product);
            }
            catch (Exception e)
            {
                throw new Exception($"Произошла ошибка при удалении продукта: {e.Message}");
            }
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
