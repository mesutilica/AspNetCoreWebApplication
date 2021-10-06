using AspNetCoreWebApplication.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using BL;

namespace AspNetCoreWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSession();
            services.AddDbContext<DatabaseContext>(); //projedeki 
            //services.AddDbContext<DataBaseContext>(); //DAL katman�ndaki
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Admin/Login";
            });

            //DI ile servis ekleme y�ntemleri

            //services.AddScoped();  Uygulama �al��ma zaman�nda her bir istek, i�lem veya hareket i�in �retilir. 

            //services.AddSingleton(); >> Uygulama aya�a kalkarken �al��an �ConfigureServices� metodunda bu metod ile tan�mlad���n�z her s�n�ftan sadece bir �rnek olu�turulur. Her kim ve nereden �a��r�rsa �a��rs�n yaln�zca bu tek �rnek kullan�lacakt�r. Uygulama yeniden ba�lay�ncaya kadar bir yenisi �retilmez. 

            //services.AddTransient(); Uygulama �al��ma zaman�nda belirli ko�ullarda �retilir veya varolan �rne�i kullan�l�r. 

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //Sana IRepository kullanma iste�i gelirse, Repository s�n�f�ndan bir nesne olu�tur ve onu g�nder
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//Uygulamada oturum a�ma i�lemini aktif et. Dikkat! oturum i�leminde �nce bu sat�r sonra alttaki sat�r gelmeli yoksa oturum a�ma i�lemi �al��maz!!!
            app.UseAuthorization(); //Yetkilendirmeyi aktif et

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
