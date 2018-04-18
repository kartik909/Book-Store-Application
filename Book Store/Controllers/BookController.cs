using Book_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class BookController : Controller
    {
        public ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = _context.Book.ToList();

            if(books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Book/id
        public ActionResult Details(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        public ActionResult New()
        {
            var book = new Book();
            return View(book); // problem solved of getting id value null at validation form but it give default values to the view that need to be solved
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View("New", book);
            }
                if (book.Id == 0)
                {
                    _context.Book.Add(book);
                }
                else
                {
                    var bookDb = _context.Book.SingleOrDefault(c => c.Id == book.Id);

                    bookDb.Name = book.Name;
                    bookDb.Author = book.Author;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
        
        public ActionResult Edit(int id)
        {
            var book = _context.Book.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            }

            return View("New", book);
        }

        public ActionResult Delete(int id)
        {
                var book = _context.Book.SingleOrDefault(c => c.Id == id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

    }
}