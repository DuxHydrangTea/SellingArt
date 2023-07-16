using Microsoft.AspNetCore.Mvc;
using ArtSocial.Models;

namespace ArtSocial.Components
{
    [ViewComponent(Name ="MenuView")]
    public class MenuViewComponents:ViewComponent
    {
        private DataContext _dataContext;
        public MenuViewComponents(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmn = (
                from m in _dataContext.Menus
                where m.ofAdmin == false
                select m
                ).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listmn));
        }
    }
}
