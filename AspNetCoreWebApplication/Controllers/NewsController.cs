using BL;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class NewsController : Controller
    {
        NewsManager newsManager = new NewsManager();
        public IActionResult Index()
        {
            return View(newsManager.GetAll());
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = newsManager.Find(id.Value);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}
