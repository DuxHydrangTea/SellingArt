using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtSocial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext dataContext;
        public MenuController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var mn = dataContext.Menus.Where(m => m.ofAdmin == false).OrderBy(m => m.MenuID).ToList();
            return View(mn);
        }
        public IActionResult Create()
        {
            var listcha = (
                from m in dataContext.Menus
                where m.ParentID == 0 && m.ofAdmin == false
                select new SelectListItem()
                {
                    Text = m.MenuName,
                    Value = m.MenuID.ToString()
                }).ToList();
            listcha.Insert(0, new SelectListItem()
            {
                Text ="-- None --",
                Value = "0",
            }
                );
            ViewBag.listcha = listcha;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.ofAdmin = false;
                dataContext.Menus.Add(menu);
                dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var mn = dataContext.Menus.Find(id);
            if(mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var mn = dataContext.Menus.Find(id);
            if(mn == null)
            {
                return NotFound();
            }
            dataContext.Menus.Remove(mn);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            var xx = dataContext.Menus.Find(id);
            if(xx == null)
            {
                return NotFound();
            }
            var listcha = (
                from m in dataContext.Menus
                where m.ParentID == 0 && m.ofAdmin == false
                select new SelectListItem()
                {
                    Text = m.MenuName,
                    Value = m.MenuID.ToString()
                }).ToList();
            listcha.Insert(0, new SelectListItem()
            {
                Text = "-- None --",
                Value = "0",
            }
                );
            ViewBag.listcha = listcha;
            return View(xx);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
            dataContext.Menus.Update(mn);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }
    }
}
