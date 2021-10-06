using BL;
using Entites;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Controllers
{
    public class PostsController : Controller
    {
        //PostManager postManager = new PostManager();
        private readonly IRepository<Post> _postService;

        public PostsController(IRepository<Post> postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View(_postService.GetAll());//postManager
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postService.Find(id.Value);//postManager
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
