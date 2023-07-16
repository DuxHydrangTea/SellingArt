using ArtSocial.Utilities;
using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtSocial.Components
{
    [ViewComponent(Name = "ManagerArtView")]
    public class ManagerArtViewComponent:ViewComponent
    {
        private DataContext _dataContext;
        public ManagerArtViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmn = (
                from m in _dataContext.Products
                where m.UserID == Functions._UserID
                select m
                ).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listmn));
        }
    }
}
