using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Dal.Models
{
    public class SectionImage
    {
        public SectionImage(string imageName, byte[] data)
        {
            ImageName = imageName;
            Data = data;
        }

        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] Data { get; set; }
        public int  SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }
    }
}