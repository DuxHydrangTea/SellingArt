using Microsoft.AspNetCore.Mvc;
using ArtSocial.Models;
namespace ArtSocial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext dataContext;
        public ProductController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var prod= dataContext.Products.ToList();
            return View(prod);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = dataContext.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var mn = dataContext.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            dataContext.Products.Remove(mn);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult WaitingAccept()
        {
            var wac = dataContext.Products.Where(m => m.Accept == false).ToList();
            
            return View(wac);
        }


        public IActionResult Accept(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = dataContext.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Accept(Product mn)
        {
            if (ModelState.IsValid)
            {
                dataContext.Products.Update(mn);
                dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
