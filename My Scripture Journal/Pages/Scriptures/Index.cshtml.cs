using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace My_Scripture_Journal.Pages.Scriptures
{
    
    public class IndexModel : PageModel
    {
        // Attributes
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;
        public IList<Scripture> Scripture { get; set; } = default!;
        public static readonly FilterViewModel BlankFilter = new FilterViewModel();
        public FilterViewModel ViewModel { get; set; } = BlankFilter;
        public List<SelectListItem> BookSelectList { get; set; }


        // Methods
        public IndexModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
        {
            _context = context;
            PopulateList();
        }

        public void PopulateList()
        {
            BookSelectList = Enum.GetValues(typeof(ScriptureBook))
                .Cast<ScriptureBook>()
                .Select(book => new SelectListItem
                {
                    Text = My_Scripture_Journal.Pages.Shared.BookSelectModel.GetBookName(book.ToString()),
                    Value = book.ToString()
                })
                .ToList();
        }

        public async Task OnGetAsync(string book,string keyword, string topic, string sort_by)
        {
            ViewModel = new FilterViewModel(keyword, book, topic, sort_by);

            var scriptures = from m in _context.Scripture
                             select m;

            if (_context.Scripture != null) 
            {
                scriptures = getFilter(ViewModel.keyword, ViewModel.book, ViewModel.topic, ViewModel.sortBy);
            }
            Scripture = await scriptures.ToListAsync();
        }

        private IQueryable<Scripture> getFilter(string keyword, string book, string topic, string sortBy)
        {
            var scriptures = from m in _context.Scripture
                             select m;

            if (!string.IsNullOrEmpty(keyword))
            {
                // Checks that s.Notes is not null before searching it for a keyword
                scriptures = scriptures.Where(s => s.Notes.Contains(keyword));
                Console.WriteLine("___________Filtered Keywords");
            }
            if (!string.IsNullOrEmpty(book))
            {
                ScriptureBook sBook = (ScriptureBook)Enum.Parse(typeof(ScriptureBook),book);
                scriptures = scriptures.Where(s => s.Book == sBook);
                Console.WriteLine("___________Filtered Books");
            }
            if (!string.IsNullOrEmpty(topic))
            {
                ScriptureTopic sTopic = (ScriptureTopic)Enum.Parse(typeof(ScriptureTopic), topic);
                scriptures = scriptures.Where(s => s.Topic == sTopic);
                Console.WriteLine("___________Filtered Topics");
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                Console.WriteLine("__________________ SortBy= " +  sortBy);
                if (sortBy == "Book")
                {
                    scriptures = scriptures.OrderBy(s => s.Book);
                    Console.WriteLine("___________Sorted By Book");
                }
                else if (sortBy == "Date")
                {
                    scriptures = scriptures.OrderBy(s => s.CreationDate);
                    Console.WriteLine("___________Sorted By Date");
                }
            }

            return scriptures;
        }



        public async Task OnPostAsyncClearForm()
        {
            
        }

    }
    
}

public class FilterViewModel
{
    public string keyword { get; set; } = "";
    public string book { get; set; } = "";
    public string topic { get; set; } = "";
    public string sortBy { get; set; } = "";

    public FilterViewModel(string _keyword="", string _book = "", string _topic = "", string _sortBy = "")
    {
        keyword = _keyword;
        book = _book;
        topic = _topic;
        sortBy = _sortBy;
    }
}


