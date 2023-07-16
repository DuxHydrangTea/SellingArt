﻿using Microsoft.AspNetCore.Mvc;
using ArtSocial.Models;
namespace ArtSocial.Components
{
    [ViewComponent(Name ="LastestProductView")]
    public class LastestProductViewComponents:ViewComponent
    {
        private DataContext _dataContext;
        public LastestProductViewComponents(DataContext dataContext)
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
