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
    }
}
