namespace OnlineStore.Web.Models
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
    }
}
