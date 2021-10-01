using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Başlık"), StringLength(150)]
        public string Name { get; set; }
        [Display(Name = "Açıklama"), DataType(DataType.Html), StringLength(250)]
        public string Description { get; set; }
        [Display(Name = "Slide Resmi")]
        public string Image { get; set; }
        [Display(Name = "Başlık Link"), StringLength(100)]
        public string Link { get; set; }
    }
}
