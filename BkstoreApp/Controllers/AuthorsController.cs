using BkstoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BkstoreApp.Controllers
{
    public class AuthorsController : Controller
    {
        public static List<Author> authors = new List<Author>();
        public static int NextId = 1;
        public IActionResult Index()
        {
            return View(authors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if(ModelState.IsValid)
            {
                author.Id = NextId++;
                authors.Add(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = authors.FirstOrDefault(a=>a.Id== id);
            if(author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPut]
        public IActionResult Edit(Author author)
        {
            if(ModelState.IsValid)
            {
                var existingAuthor = authors.FirstOrDefault(a => a.Id == author.Id);
                if(existingAuthor == null)
                {
                    return NotFound();
                }
                existingAuthor.Name = author.Name;
                return RedirectToAction("Index");
            }
            return View(author);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var author = authors.FirstOrDefault(a=>a.Id == id);
            if (author != null)
            {
                authors.Remove(author);

            }
            return RedirectToAction("Index");
        }

    }
}
