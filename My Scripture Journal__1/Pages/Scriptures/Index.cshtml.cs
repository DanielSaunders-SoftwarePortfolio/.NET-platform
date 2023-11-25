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
    public class IndexModel : PageModel
    {
        private readonly My_Scripture_Journal__1.Data.My_Scripture_Journal__1Context _context;

        public IndexModel(My_Scripture_Journal__1.Data.My_Scripture_Journal__1Context context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Scripture != null)
            {
                Scripture = await _context.Scripture.ToListAsync();
            }
        }
    }
}
