using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Hosting;


namespace MvcMovie.Controllers
{
    public class
        MoviesController : Controller
    {
        private readonly MvcMovieContext _context;
        private IWebHostEnvironment _webHostEnvironment { get; set; }
        public MoviesController(MvcMovieContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString, bool sortByDate)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            Console.WriteLine(sortByDate);
            if (sortByDate)
            {
                movies = movies.OrderByDescending(x => x.ReleaseDate);
            }
            else
            {
                movies = movies.OrderBy(x => x.Title);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(movie);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating,CoverPhoto")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.CoverPhoto != null)
                {
                    // Save the uploaded file to a folder within the project
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Resources");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.CoverPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await movie.CoverPhoto.CopyToAsync(stream);
                    }

                    // Save the file path in the Movie object
                    movie.CoverPhotoPath = Path.Combine("Resources", uniqueFileName);
                }
                _context.Add(movie);
                await _context.SaveChangesAsync();

                // Save the movie object to the database or perform other actions

                return RedirectToAction("Index");
            }

            return View(movie);
        }



        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating,CoverPhoto")] Movie movie)
        {
            Console.WriteLine("Entering Edit");
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingMovie = await _context.Movie.FindAsync(id);

                Console.WriteLine("IsValid");
                if (movie.CoverPhoto != null)
                {
                    // Save the uploaded file to a folder within the project
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Resources");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.CoverPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await movie.CoverPhoto.CopyToAsync(stream);
                    }

                    // Save the file path in the Movie object
                    movie.CoverPhotoPath = Path.Combine("Resources", uniqueFileName);
                    Console.WriteLine();
                    Console.WriteLine("New Image Path");
                    Console.WriteLine(movie.CoverPhotoPath);
                    Console.WriteLine();
                }
                else
                {
                    movie.CoverPhotoPath = existingMovie.CoverPhotoPath;
                    Console.WriteLine();
                    Console.WriteLine("Old Image Path");
                    Console.WriteLine(movie.CoverPhotoPath);
                    Console.WriteLine();
                }

                try
                {
                    existingMovie.Title = movie.Title;
                    existingMovie.ReleaseDate = movie.ReleaseDate;
                    existingMovie.Genre = movie.Genre;
                    existingMovie.Price = movie.Price;
                    existingMovie.Rating = movie.Rating;
                    existingMovie.CoverPhotoPath = movie.CoverPhotoPath;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
