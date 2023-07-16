using ArtSocial.Models;
using ArtSocial.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ArtSocial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginAdminController : Controller
    {
        private readonly DataContext _context;
        public LoginAdminController(DataContext context)
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
            var check = _context.Users.Where(m => (m.UserName == user.UserName) && (m.Password == pw) ).FirstOrDefault();
            if (check == null || check.isAdmin == false)
            {
                Functions._Message = "Tên đăng nhập hoặc mật khẩu khum đúng =)";
                return RedirectToAction("Index", "Loginadmin");
            }
            Functions._AdminID = check.UserID;
            Functions._AdminUser = String.IsNullOrEmpty(check.UserName) ? String.Empty : check.UserName;
            return RedirectToAction("Index", "Home");
        }
    }
}
