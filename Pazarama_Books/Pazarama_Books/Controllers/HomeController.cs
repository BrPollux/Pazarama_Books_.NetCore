using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pazarama_Books.Data;
using Pazarama_Books.Models;
using Pazarama_Books.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pazarama_Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksDbContext _context;

        public HomeController(BooksDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var model = new HomePageViewModel
            {
                PopularBooks = _context.Books.ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
