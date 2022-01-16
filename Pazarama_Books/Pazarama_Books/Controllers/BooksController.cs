using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pazarama_Books.Data;
using Pazarama_Books.Entity;
using Pazarama_Books.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazarama_Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksDbContext _context;
        public BooksController(BooksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(int? id, string q)
        {
            var books = _context.Books.AsQueryable();

            if (id != null)
            {
                books = books
                    .Include(m => m.Genres)
                    .Where(m => m.Genres.Any(g => g.GenreId == id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                books = books.Where(i =>
                    i.Title.ToLower().Contains(q.ToLower()) ||
                    i.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new BooksViewModel()
            {
                Books = books.ToList()
            };

            return View("Books", model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Books.Find(id));
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book m)
        {

            _context.Books.Update(m);
            _context.SaveChanges();
            return RedirectToAction("List", "Books", new { @id = m.BookId });


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book m)
        {
            _context.Books.Add(m);
            _context.SaveChanges();
            TempData["Message"] = $"{m.Title} isimli kitap eklendi";
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int MovieId, string Title)
        {
            var entity = _context.Books.Find(MovieId);
            _context.Books.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"{Title} isimli kitap silindi";
            return RedirectToAction("List");
        }


    }
}
