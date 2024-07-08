using BkstoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BkstoreApp.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> books = new List<Book>();
        public static int NextId = 1;

        public IActionResult Index()
        {
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = NextId++;
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPut]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook == null)
                {
                    return NotFound();
                }
                existingBook.Title = book.Title;
                existingBook.ISBN = book.ISBN;
                existingBook.AuthorId = book.AuthorId;
                existingBook.CategoryId = book.CategoryId;
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction("Index");
        }
    }
}
