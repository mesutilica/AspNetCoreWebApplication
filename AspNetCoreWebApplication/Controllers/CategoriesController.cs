using BL;
using Entites;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        //PostManager postManager = new PostManager();
        //CategoryManager categoryManager = new CategoryManager();

        //DI ile servis kullanım
        private readonly IRepository<Post> _postService;
        private readonly IRepository<Category> _categoryService;

        public CategoriesController(IRepository<Post> postService, IRepository<Category> categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(_postService.GetAll());//postManager
            }
            else
            {
                ViewBag.KategoriAdi = _categoryService.Find(id.Value).Name;//categoryManager
                //return View(_postService.GetAll(x => x.CategoryId == id));//postManager
                return View();
            }
        }
    }
}
