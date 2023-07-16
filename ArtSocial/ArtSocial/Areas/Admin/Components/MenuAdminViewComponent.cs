using Microsoft.AspNetCore.Mvc;
using ArtSocial.Models;
using Microsoft.EntityFrameworkCore;
namespace ArtSocial.Areas.Admin.Components
{
    [ViewComponent(Name ="MenuAdminView")]
    public class MenuAdminViewComponent: ViewComponent
    {
        private DataContext _dataContext;
        public MenuAdminViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmn = (
                from m in _dataContext.Menus
                where m.ofAdmin == true
                select m
                ).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listmn));
        }
    }
}
