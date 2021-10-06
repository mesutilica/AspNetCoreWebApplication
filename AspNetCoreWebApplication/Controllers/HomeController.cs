using AspNetCoreWebApplication.Models;
using BL;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// S.O.L.I.D = Yazılım prensipleri -- DI

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //SliderManager sliderManager = new SliderManager();
        //NewsManager newsManager = new NewsManager();
        //PostManager postManager = new PostManager();
        //ContactManager contactManager = new ContactManager();
        //Dependency Injection ile Kullanım
        private readonly IRepository<Slider> _sliderService;
        private readonly IRepository<News> _newsService;
        private readonly IRepository<Post> _postService;
        private readonly IRepository<Contact> _contactService;

        public HomeController(ILogger<HomeController> logger, IRepository<Slider> sliderService, IRepository<News> newsService, IRepository<Post> postService, IRepository<Contact> contactService)
        {
            _logger = logger;
            _sliderService = sliderService;
            _newsService = newsService;
            _postService = postService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders = _sliderService.GetAll(),//sliderManager
                News = _newsService.GetAll(),//newsManager
                Posts = _postService.GetAll()//postManager
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            try
            {
                contact.CreateDate = DateTime.Now;
                var sonuc = _contactService.Add(contact);//contactManager
                if (sonuc > 0)
                {
                    TempData["Mesaj"] = "<div class='alert alert-success'>Mesajınız Gönderilmiştir!</div>";
                }
                else TempData["Mesaj"] = "<div class='alert alert-warning'>Mesajınız Gönderilemedi!</div>";
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "<div class='alert alert-danger'>Hata Oluştu! Mesajınız Gönderilemedi!</div>";
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
