using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BL.CategoryManager categoryManager = new BL.CategoryManager();
            return View(categoryManager.GetAll());
        }
    }
}
