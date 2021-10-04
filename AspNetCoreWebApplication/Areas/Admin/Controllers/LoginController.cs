using BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            try
            {
                var kullanici = userManager.Get(x => x.Email == email && x.Password == password && x.IsActive == true);
                if (kullanici != null)
                {
                    //giriş yapacak
                }
                else
                {
                    TempData["Mesaj"] = "Giriş Başarısız!";
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }
    }
}
