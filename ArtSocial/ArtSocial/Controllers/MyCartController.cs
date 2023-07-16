using Microsoft.AspNetCore.Mvc;
using ArtSocial.Utilities;
using ArtSocial.Models;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;

namespace ArtSocial.Controllers
{
    public class MyCartController : Controller
    {
        private readonly DataContext _context;
        public MyCartController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = (
                from m in _context.detailMyCarts
                where m.UserBuyID == Functions._UserID
                select m
                ).ToList();

            //var cart2 = _context.detailMyCarts.Where(m => m.UserBuyID == 2).ToList();
            return View(cart);
        }


        public IActionResult AddtoCart(int ArtID)
        {
            
                var toCart = new MyCart();
                toCart.ArtID = ArtID;
                toCart.UserBuyID = Functions._UserID;
                _context.Add(toCart);
                _context.SaveChanges();
                return View();
        }


        public IActionResult DeleteonCart(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.MyCarts.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteonCart(int id)
        {
            var mn = _context.MyCarts.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            _context.MyCarts.Remove(mn);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
