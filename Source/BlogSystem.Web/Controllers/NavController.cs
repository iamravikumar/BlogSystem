﻿namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Data.Repositories;
    using ViewModels.Nav;
    using Infrastructure.Extensions;

    public class NavController : BaseController
    {
        private readonly IDbRepository<Page> pagesRepository;

        public NavController(IDbRepository<Page> pagesRepository)
        {
            this.pagesRepository = pagesRepository;
        }

        [ChildActionOnly]
        [OutputCache(Duration = 6 * 10 * 60)]
        public PartialViewResult Menu()
        { 
            var model = this.Cache.Get("Menu", () => 
                this.pagesRepository
                    .All()
                    .Where(p => p.VisibleInMenu)
                    .To<MenuItemViewModel>()
                    .ToList(),
                600);

            return this.PartialView(model);
        }
    }
}