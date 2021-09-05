using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using OnlineStore.Dal.Models;

namespace OnlineStore.Web.Models
{
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
        public Section Section { get; set; }
        public Product Product { get; set; }
    }
}
