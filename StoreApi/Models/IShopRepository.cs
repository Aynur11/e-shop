using System;
using System.Collections.Generic;

namespace StoreApi.Models
{
    public interface IShopRepository : IDisposable
    {
        List<Section> Sections { get; }

        List<Product> Products { get; }

        List<ProductImage> ProductImages { get; }

        void Add(Section section);

        void Add(Product product);

        void Remove(Section section);

        void Remove(Product product);

        void Save();
    }
}
