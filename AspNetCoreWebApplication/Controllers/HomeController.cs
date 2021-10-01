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

namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        SliderManager sliderManager = new SliderManager();
        NewsManager newsManager = new NewsManager();
        PostManager postManager = new PostManager();
        ContactManager contactManager = new ContactManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Sliders = sliderManager.GetAll(),
                News = newsManager.GetAll(),
                Posts = postManager.GetAll()
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
                var sonuc = contactManager.Add(contact);
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
