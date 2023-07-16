using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtSocial.Controllers
{
    public class ChangeMyInfoController : Controller
    {
        private readonly DataContext _context;
        public ChangeMyInfoController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int ?id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var info = _context.Users.Find(id);
            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User mn)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(mn);
                _context.SaveChanges();
                return Redirect("/MyAccount/Index");
            }
            return View();
        }
    }
}
