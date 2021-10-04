using BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Controllers
{
    public class PostsController : Controller
    {
        PostManager postManager = new PostManager();
        public IActionResult Index()
        {
            return View(postManager.GetAll());
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = postManager.Find(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
