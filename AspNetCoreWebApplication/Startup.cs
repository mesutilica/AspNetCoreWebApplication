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
            //services.AddDbContext<DataBaseContext>(); //DAL katmanýndaki
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Admin/Login";
            });

            //DI ile servis ekleme yöntemleri

            //services.AddScoped();  Uygulama çalýþma zamanýnda her bir istek, iþlem veya hareket için üretilir. 

            //services.AddSingleton(); >> Uygulama ayaða kalkarken çalýþan “ConfigureServices” metodunda bu metod ile tanýmladýðýnýz her sýnýftan sadece bir örnek oluþturulur. Her kim ve nereden çaðýrýrsa çaðýrsýn yalnýzca bu tek örnek kullanýlacaktýr. Uygulama yeniden baþlayýncaya kadar bir yenisi üretilmez. 

            //services.AddTransient(); Uygulama çalýþma zamanýnda belirli koþullarda üretilir veya varolan örneði kullanýlýr. 

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //Sana IRepository kullanma isteði gelirse, Repository sýnýfýndan bir nesne oluþtur ve onu gönder
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

            app.UseAuthentication();//Uygulamada oturum açma iþlemini aktif et. Dikkat! oturum iþleminde önce bu satýr sonra alttaki satýr gelmeli yoksa oturum açma iþlemi çalýþmaz!!!
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
