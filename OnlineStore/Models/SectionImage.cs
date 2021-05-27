using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class SectionImage
    {
        public SectionImage(byte[] data)
        {
            //FilePath = filePath;
            Data = data;
        }

        public int Id { get; set; }
        //public string FilePath { get; set; }
        public byte[] Data { get; set; }
        public int  SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }
    }
}