using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using OnlineStore.Dal;
using OnlineStore.Dal.Models;

namespace OnlineStore.Web.Models
{
    /// <summary>
    /// Класс для обращения к Web-API онлайн-магазина.
    /// </summary>
    public class ShopApiClient : IShopRepository
    {
        private HttpClient HttpClient { get; }

        private bool disposed;
        private readonly DataContext context;

        public List<Section> Sections
        {
            get
            {
                string url = "https://localhost:44379/api/Sections/GetSections";
                var json = HttpClient.GetStringAsync(url).Result;
               return JsonConvert.DeserializeObject<List<Section>>(json);
            }
        }

        public List<Product> Products
        {
            get
            {
                string url = "https://localhost:44379/api/Products/GetProducts";
                var json = HttpClient.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }

        public List<ProductImage> ProductImages
        {
            get
            {
                string url = "https://localhost:44379/api/Products/GetProductImages";
                var json = HttpClient.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<List<ProductImage>>(json);
            }
        }


        public ShopApiClient(DataContext context, HttpClient httpClient)
        {
            this.context = context;
            this.HttpClient = httpClient;
        }

        public void Add(Section section)
        {
            string url = "https://localhost:44379/api/Sections/AddSection";
            var httpContent = new StringContent(JsonConvert.SerializeObject(section), Encoding.UTF8, "application/json");
            HttpClient.PostAsync(url, httpContent);
        }

        public void Add(Product product)
        {
            //context.Products.Add(product);

            string url = "https://localhost:44379/api/Products/AddProduct";
            var httpContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            HttpClient.PostAsync(url, httpContent);
        }

        public void Remove(Section section)
        {
            //context.Sections.Remove(section);
            string url = "https://localhost:44379/api/Sections/RemoveSection";
            var httpContent = new StringContent(JsonConvert.SerializeObject(section), Encoding.UTF8, "application/json");
            HttpClient.PostAsync(url, httpContent);
        }

        public void Remove(Product product)
        {
            //context.Products.Remove(product);
            string url = "https://localhost:44379/api/Products/RemoveProduct";
            var httpContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            HttpClient.PostAsync(url, httpContent);
        }

        /// <summary>
        /// Обновляет свойства сущности в БД после редактирования.
        /// </summary>
        /// <param name="section"></param>
        public void Update(Section section)
        {
            string url = "https://localhost:44379/api/Sections/UpdateSection";
            var httpContent = new StringContent(JsonConvert.SerializeObject(section), Encoding.UTF8, "application/json");
            HttpClient.PostAsync(url, httpContent);
        }

        /// <summary>
        /// Обновляет свойства сущности в БД после редактирования.
        /// </summary>
        public void Update(Product product)
        {
            string url = "https://localhost:44379/api/Products/UpdateProduct";
            var httpContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            HttpClient.PostAsync(url, httpContent);
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
