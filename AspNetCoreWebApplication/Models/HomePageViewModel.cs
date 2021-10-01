using Entites;
using System.Collections.Generic;

namespace AspNetCoreWebApplication.Models
{
    public class HomePageViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<News> News { get; set; }
        public List<Post> Posts { get; set; }
    }
}
