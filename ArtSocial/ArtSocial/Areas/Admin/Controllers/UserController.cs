using ArtSocial.Models;
using ArtSocial.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSocial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private  readonly DataContext dataContext;
        public UserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var users = dataContext.Users.Where(m => m.isAdmin == false).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(User user)
        {
            if(user == null)
            {
                return NotFound();
            }
            var check = dataContext.Users.Where(m => m.UserName == user.UserName).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Ten dang nhap da ton tai";
                return RedirectToAction("Index");
            }
            Functions._Message = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            dataContext.Add(user);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return View(dataContext.Users.Find(id));
        }
        [HttpPost]
        public IActionResult  Delete(int id)
        {
            var usedelete = dataContext.Users.Find(id);
            if(usedelete == null)
            {
                return NotFound();
            }
            dataContext.Users.Remove(usedelete);
            dataContext.SaveChanges();
            return View("Index");
        }
    }
}
