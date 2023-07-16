using ArtSocial.Models;
using ArtSocial.Utilities;
using Microsoft.AspNetCore.Mvc;
namespace ArtSocial.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }

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
            string pw = Functions.MD5Password(user.Password);
            var check = _context.Users.Where(m => (m.UserName == user.UserName) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Tên đăng nhập hoặc mật khẩu khum đúng =)";
                return RedirectToAction("Index", "Login");
            }
            Functions._isLogin = true;
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = String.IsNullOrEmpty(check.UserName) ? String.Empty : check.UserName;
            return RedirectToAction("Index", "Home");
        }
    }
}
