using Microsoft.AspNetCore.Mvc;
using Pazarama_Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazarama_Books.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly BooksDbContext _context;
        public GenresViewComponent(BooksDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.Genres.ToList());
        }

    }
}
