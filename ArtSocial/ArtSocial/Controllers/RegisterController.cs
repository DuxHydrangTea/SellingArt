using ArtSocial.Models;
using ArtSocial.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSocial.Controllers
{

    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context) { _context = context; }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.Users.Where(m => m.UserName == user.UserName).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Ten dang nhap da ton tai";
                return RedirectToAction("Index", "Register");
            }
            Functions._Message = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            user.isAdmin = false;
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
