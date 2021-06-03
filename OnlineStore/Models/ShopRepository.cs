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

        public ShopRepository()
        {
            context = new DataContext();
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
