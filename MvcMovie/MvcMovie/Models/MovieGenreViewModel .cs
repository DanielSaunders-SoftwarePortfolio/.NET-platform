using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class MovieGenreViewModel
{
    public List<Movie>? Movies { get; set; }
    
    private static readonly string[] PossibleGenres = {
            "Action", "Adventure", "Comedy", "Drama", "Horror",
            "Sci-Fi", "Thriller", "Romance", "Fantasy", "Mystery",
            "Animation", "Crime", "Family", "History", "Music",
            "Sport", "War", "Western", "Documentary", "Religion", 
            "Other"
        };

    public static SelectList? Genres = new SelectList(PossibleGenres);

    [Display(Name = "Genre")]
    public string? MovieGenre { get; set; }

    [Display(Name = "Title")]
    public string? SearchString { get; set; }

    [Display(Name = "Sort Method")]
    public bool? SortByDate { get; set; }

}