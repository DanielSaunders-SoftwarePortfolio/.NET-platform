using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Models;
using My_Scripture_Journal__1.Data;

namespace My_Scripture_Journal__1.Pages.Scriptures
{
    public class DeleteModel : PageModel
    {
        private readonly My_Scripture_Journal__1.Data.My_Scripture_Journal__1Context _context;

        public DeleteModel(My_Scripture_Journal__1.Data.My_Scripture_Journal__1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Scripture Scripture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }

            var scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.Id == id);

            if (scripture == null)
            {
                return NotFound();
            }
            else 
            {
                Scripture = scripture;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }
            var scripture = await _context.Scripture.FindAsync(id);

            if (scripture != null)
            {
                Scripture = scripture;
                _context.Scripture.Remove(Scripture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
