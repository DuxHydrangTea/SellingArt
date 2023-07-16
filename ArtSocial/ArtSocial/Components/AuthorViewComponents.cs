using Microsoft.AspNetCore.Mvc;
using ArtSocial.Models;
namespace ArtSocial.Components
{
    [ViewComponent(Name ="AuthorView")]
    public class AuthorViewComponents:ViewComponent
    {
        private DataContext _dataContext;
        public AuthorViewComponents(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listmn = (
                from m in _dataContext.Users
                select m
                ).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listmn));
        }
    }
}
