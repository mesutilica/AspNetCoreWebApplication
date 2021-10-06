using BL;
using Entites;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplication.Controllers
{
    public class NewsController : Controller
    {
        //NewsManager newsManager = new NewsManager();
        private readonly IRepository<News> _newsService;

        public NewsController(IRepository<News> newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            return View(_newsService.GetAll());//newsManager
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = _newsService.Find(id.Value);//newsManager
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
    }
}
