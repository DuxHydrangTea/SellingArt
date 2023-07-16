using ArtSocial.Components;
using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using ArtSocial.Utilities;
namespace ArtSocial.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;


        public ProductController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("/list-tac-pham{id:int}")]
        public IActionResult Index(int? id)
        {
            if(id == null || id ==0)
            {
                var mn = (
                    from m in _context.DetailProducts
                    select m
                    ).OrderByDescending(m=> m.CreatedDate).ToList();
                return View(mn);
            }
            else
            {
                var vl = _context.DetailProducts.Where(m => m.CategoryID == id).ToList();
                //var ml = (
                //    from m in _context.DetailProducts
                //    where m.CategoryID == id
                //    select m
                //    ).ToList();
                return View(vl);
            }
        }

        [HttpGet("/tac-pham-{id:int}")]
        public IActionResult DetailProduct(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var dp = _context.DetailProducts.FirstOrDefault(m => m.ArtID == id);
                return View(dp);
            }
            
        }


        public IActionResult Comment_Acction(string? commentstext, string ArtID)
        {
            if (ModelState.IsValid)
            {
                BaseComment comment = new BaseComment();
                comment.CreatedDate = DateTime.Now;
                comment.ArtID = int.Parse(ArtID);
                comment.CommentText = commentstext;
                comment.UserID = Functions._UserID;
                _context.baseComments.Add(comment);
                _context.SaveChanges();
                
            }
            string retu = "/tac-pham-" + ArtID;
            return Redirect(retu);
        }



        public IActionResult AddProduct()
        {
            var listCate = (
                from m in _context.Categories
                select new SelectListItem()
                {
                    Text = m.CategoryName,
                    Value = m.CategoryID.ToString()
                }
      ).ToList();
            ViewBag.listCate = listCate;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                product.UserID = Functions._UserID;
                product.Accept = false;
                _context.Products.Add(product);
                _context.SaveChanges();
                Functions._uploaddone = "Upload thành công";
            }
            return Redirect("AddProduct");
        }

        public IActionResult Search(string str)
        {
            var results = _context.DetailProducts
                             .Where(t => t.ArtName.Contains(str))
                             .ToList();
            return View(results);
        }
    }
}
