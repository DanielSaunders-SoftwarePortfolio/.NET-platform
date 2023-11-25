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
using Microsoft.AspNetCore.Components;

namespace My_Scripture_Journal.Pages.Shared
{
    public class ReferenceViewModel : ViewComponent
    {
        [Parameter]
        public Scripture? Scripture { get; set; } = null;
        public String Reference { get; set; } = "";
        public ReferenceViewModel(My_Scripture_Journal.Models.Scripture scripture)
        {
            Scripture = scripture;
            Reference = $"{Scripture.GetBookName()} {Scripture.Chapter}:{Scripture.StartVerse}";
            if (Scripture.StartVerse != Scripture.EndVerse)
            {
                Reference += $"-{Scripture.EndVerse}";
            }
        }
    }
}
