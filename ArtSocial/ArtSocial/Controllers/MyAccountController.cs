using Microsoft.AspNetCore.Mvc;
using ArtSocial.Utilities;
using ArtSocial.Models;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtSocial.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly DataContext context;
        public MyAccountController(DataContext context)
        {
            this.context = context;

        }
        public IActionResult Index()
        {
            if (Functions._UserID == 0)
            {
                return RedirectToAction("index", "Login");

                
            }
            var x = context.Users.FirstOrDefault(m => m.UserID == Functions._UserID);
            return View(x); ;
        }

        public IActionResult EditMyArt(int? id)
        {
            var listCate = (
              from m in context.Categories
              select new SelectListItem()
              {
                  Text = m.CategoryName,
                  Value = m.CategoryID.ToString()
              }
                 ).ToList();
            ViewBag.listCate = listCate;
            var xx= context.Products.Find(id);
            if(xx == null)
            {
                return NotFound();
            }
            return View(xx);
        }

        [HttpPost]        
        public IActionResult EditMyArt(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }


        public IActionResult ChangeMyInfo(int? id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult ChangeMyInfo(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Update(user);
                context.SaveChanges();
                return RedirectToAction("MyAccount","Index");
            }
            return View();
        }



       
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string oldPass, string newPass)
        {
           
            return View();
        }


        public IActionResult DeleteMyProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = context.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
       
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMyProduct(int id)
        {
            var mn = context.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            context.Products.Remove(mn);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
