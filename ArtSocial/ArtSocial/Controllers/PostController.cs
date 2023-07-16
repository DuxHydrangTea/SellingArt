using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ArtSocial.Controllers
{
    public class PostController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PostController(DataContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

       




        public IFormFile image { get; set; }

        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(Post post)
        {

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "~/Web/images", image.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                string pathimg = "~/Web/images" + fileName;
                post.ImagePath = pathimg;
                _context.posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

    }
}
