using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Book_Store.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Book> Book { get; set; }
    }
}