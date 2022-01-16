using Microsoft.EntityFrameworkCore;
using Pazarama_Books.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazarama_Books.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
