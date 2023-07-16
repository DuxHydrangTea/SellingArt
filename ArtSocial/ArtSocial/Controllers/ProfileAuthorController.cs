using ArtSocial.Components;
using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using ArtSocial.Utilities;

namespace ArtSocial.Controllers
{

    public class ProfileAuthorController : Controller
    {
        private readonly DataContext context;
        public ProfileAuthorController(DataContext context)
        {
            this.context = context;

        }
        [Route("/profile-author-{id:int}")]
        public IActionResult Index(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            else {
                var author = context.Users.FirstOrDefault( m => m.UserID == id);
            return View(author);
        }
        }
    }
}
