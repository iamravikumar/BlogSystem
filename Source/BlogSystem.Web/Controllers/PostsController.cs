﻿namespace BlogSystem.Web.Controllers
{ 
    using System.Web.Mvc;
    using Data.Models;
    using Data.Repositories;
    using ViewModels.Post;

    public class PostsController : BaseController
    {
        private readonly IDbRepository<Post> postsRepository;

        public PostsController(IDbRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public ActionResult Post(int id)
        {
            var post = this.postsRepository.Find(id);
            var model = this.Mapper.Map<PostViewModel>(post);

            return this.View(model);
        }
    }
}