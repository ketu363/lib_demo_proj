using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Library.ViewModels;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Books
        public ViewResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();
            return View(books);
        }
        //GET: Books/Details
        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }
        //GET: Books/Random
        public ActionResult Random()
        {
            return View();
        }
        //Book Edit
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
         

            if(book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);
        }
        
        //Book Create
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };
            return View("BookForm", viewModel);
        }
        //Book Save
        [HttpPost]
        public ActionResult Save(Book book)
        {
            if(book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
       
    }
}