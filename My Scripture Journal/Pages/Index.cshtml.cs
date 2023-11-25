using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Models;

namespace Scripture_Tracker.Pages
{
    public class IndexModel : PageModel
    {
        private const string HomePageName = "/Scriptures/Index";
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return RedirectToPage(HomePageName);
         
        }
    }
}