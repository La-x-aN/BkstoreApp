using BkstoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BkstoreApp.Controllers
{
    public class CategoriesController : Controller
    {
        public static List<Category> categories = new List<Category>();
        public static int NextId = 1;

        public IActionResult Index()
        {
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid) 
            {
                category.Id = NextId++;
                categories.Add(category);
                return RedirectToAction("Index");
            }
            return View(categories);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category= categories.FirstOrDefault(c=>c.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPut]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory= categories.FirstOrDefault(c=>c.Id==category.Id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                existingCategory.Name = category.Name;
                return RedirectToAction("Index");

            }
            return View(category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category= categories.FirstOrDefault(c=> c.Id==id);
            if(category != null)
            {
                categories.Remove(category);
            }
            return RedirectToAction("Index");

        }

    }
}
