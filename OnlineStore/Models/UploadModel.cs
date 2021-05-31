using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Models
{
    public class UploadModel : BufferedSingleFileUploadDbModel
    {
        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var image = new SectionImage(FileUpload.FormFile.Name, memoryStream.ToArray());
                    using (var db = new DataContext())
                    {
                        db.Sections.Add(new Section(FileUpload.Section.Name, image));
                        await db.SaveChangesAsync();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return Page();
        }
    }
}
