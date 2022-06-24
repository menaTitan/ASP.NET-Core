using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCLibaray.Models;

namespace MVCLibrary.Data
{
    public class LibraryContext : DbContext
    {
        private Func<DbContextOptions<LibraryContext>> getRequiredService;

        public LibraryContext (DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

    
        public DbSet<MVCLibaray.Models.Book>? Book { get; set; }
    }
}
