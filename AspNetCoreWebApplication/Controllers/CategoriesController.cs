using BL;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        PostManager postManager = new PostManager();
        CategoryManager categoryManager = new CategoryManager();
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(postManager.GetAll());
            }
            else
            {
                ViewBag.KategoriAdi = categoryManager.Find(id.Value).Name;
                return View(postManager.GetAll(x => x.CategoryId == id));
            }
        }
    }
}
