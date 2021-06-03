using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class ProductImage
    {
        public ProductImage(string imageName, byte[] data)
        {
            ImageName = imageName;
            Data = data;
        }

        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] Data { get; set; }
        //public int ProductId { get; set; }
        //[ForeignKey(nameof(ProductId))]
        //public Product Product { get; set; }
    }
}
