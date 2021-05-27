using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineStore.Models
{
    public class BufferedSingleFileUploadDbModel: PageModel
    {
        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }
    }
}
