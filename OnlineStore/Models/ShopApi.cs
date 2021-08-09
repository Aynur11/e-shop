using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OnlineStore.Models
{
    /// <summary>
    /// Класс для обращения к Web-API онлайн-магазина.
    /// </summary>
    public class ShopApi : IShopRepository
    {
        private HttpClient httpClient { get; }

        private bool disposed;
        private readonly DataContext context;

        public List<Section> Sections
        {
            get
            {
                string url = "https://localhost:44379/api/Sections/GetSections";
                var json = httpClient.GetStringAsync(url).Result;
               return JsonConvert.DeserializeObject<List<Section>>(json);
            }
        }

        public List<Product> Products
        {
            get
            {
                string url = "https://localhost:44379/api/Products/GetProducts";
                var json = httpClient.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }

        public List<ProductImage> ProductImages
        {
            get
            {
                string url = "https://localhost:44379/api/ProductsImages/GetProductImages";
                var json = httpClient.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<List<ProductImage>>(json);
            }
        }


        public ShopApi(DataContext context, HttpClient httpClient)
        {
            this.context = context;
            this.httpClient = httpClient;
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
