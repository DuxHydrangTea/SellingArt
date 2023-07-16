using ArtSocial.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtSocial.Components
{
    [ViewComponent(Name ="RecentArtView")]
    public class RecentArtViewComponents:ViewComponent
    {
        private DataContext _dataContext;
        public RecentArtViewComponents(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmn = (
                from m in _dataContext.DetailProducts
                select m
                ).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listmn));
        }
    }
}
