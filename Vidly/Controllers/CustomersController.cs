using IdentitySample.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(x => x.MembershipType).ToList();

            return View(customers);
        }

        // GET: Customers/Details
        public ActionResult Details(int? id)
        {
            var customer = db.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            //var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }
}