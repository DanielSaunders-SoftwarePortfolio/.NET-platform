using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Models;
using Microsoft.EntityFrameworkCore;

namespace My_Scripture_Journal.Pages.Shared
{
    public class BookSelectModel : ViewComponent
    {
        public List<SelectListItem> BookSelectList { get; set; }
        public string Book { get; set; } = "";
        public Scripture Scripture { get; set; } = new Scripture();
        public BookSelectModel(string book)
        {
            PopulateList();
            //Scripture.Book = (ScriptureBook)Enum.Parse(typeof(ScriptureBook), asp_for);
            Book = book;
            Scripture.Book = (ScriptureBook)Enum.Parse(typeof(ScriptureBook), book);
        }

        public void PopulateList()
        {
            BookSelectList = Enum.GetValues(typeof(ScriptureBook))
                .Cast<ScriptureBook>()
                .Select(book => new SelectListItem
                {
                    Text = GetBookName(book.ToString()),
                    Value = book.ToString()
                })
                .ToList();
        }

        public static string GetBookName(string book)
        {
            var enumType = typeof(ScriptureBook);
            var memberInfo = enumType.GetMember(book);
            if (memberInfo.Length > 0)
            {
                var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    return displayAttribute.Name;
                }
            }
            return book.ToString();
        }
    }
}
