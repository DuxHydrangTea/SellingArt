using Microsoft.AspNetCore.Mvc;
using ArtSocial.Utilities;
namespace ArtSocial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(Functions._AdminID == 0)
            {
                return Redirect("Admin/LoginAdmin");
            }
            return View();
        }
    }
}
