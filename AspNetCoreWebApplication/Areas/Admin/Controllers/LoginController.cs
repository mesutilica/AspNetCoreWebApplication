using BL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();
        public IActionResult Index()
        {
            TempData["ReturnUrl"] = HttpContext.Request.Query["ReturnUrl"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password, string ReturnUrl)
        {
            try
            {
                var kullanici = userManager.Get(x => x.Email == email && x.Password == password && x.IsActive == true);
                if (kullanici != null)
                {
                    //giriş yapacak
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, email)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);//async ile biten metotlar asenkron metotlardır ve bu metotları çalıştırmak için await anahtar kelimesi ilgili satırın başına eklenmelidir
                    if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else return Redirect("/Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Email veya Şifre Hatalı!");
                    TempData["Mesaj"] = "Giriş Başarısız!";
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
