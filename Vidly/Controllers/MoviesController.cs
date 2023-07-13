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
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id =1, Name = "ABCD2"},
                new Movie {Id =2, Name = "Ra1"}
            };
        }

        // GET: Movies/Random
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



        //[Route("movies/released/{year:regex(\\d{4}):range(1999, 2023)}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content($"Year = {year} and Month = {month}");
        //}

        //// GET: Movies/Edit
        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}

        //// GET: Movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content($"PageIndex = {pageIndex}, SortBy = {sortBy}");
        //}
    }
}