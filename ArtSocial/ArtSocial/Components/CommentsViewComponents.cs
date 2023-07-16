using Microsoft.AspNetCore.Mvc;
using ArtSocial.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtSocial.Components
{
    [ViewComponent(Name = "Comments")]
    public class CommentsViewComponents : ViewComponent
    {
        private DataContext _dataContext;
        public CommentsViewComponents(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke(int? ArtID)
        {
            var comment = _dataContext.Comments.Where(c => c.ArtID == ArtID).ToList();
            return View(comment);
        }

    }
}
