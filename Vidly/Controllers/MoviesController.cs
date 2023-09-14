using IdentitySample.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db;
        public MoviesController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }


        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
            
        }

        
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = db.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {               
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = db.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {                   
                    Genres = db.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;

                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberAvailable = movie.NumberInStock;

            }

            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Details(int? id)
        {
            var movie = db.Movies.Include(x => x.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        public ActionResult Random()
        {
            var movie = new Movie() { Name = "ABCD2" };

            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer 1"},
                new Customer {Id = 2, Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}