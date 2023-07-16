using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtSocial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryAdminController : Controller
    {
        private readonly DataContext _context;
        public CategoryAdminController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listCate = _context.Categories.ToList();
            return View(listCate);
        }

        public IActionResult Delete(int ?id)
        {
            if(id == 0) return NotFound();
            else
            {
                var cat = _context.Categories.Find(id);
                if(cat == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(cat);
                }
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cat = _context.Categories.Find(id);
            if (cat == null) return NotFound();
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                else return View(category);
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Category cate)
        {
            if(cate == null) return NotFound();
            else
            {
                _context.Categories.Update(cate);
                _context.SaveChanges();
                return View(cate);
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Category cate) 
        {
            if(cate==null) return NotFound();
            else
            {
                _context.Categories.Add(cate);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }
}
