using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "İçerik Adı"), Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "İçerik Açıklaması"), DataType(DataType.Html)]
        public string Description { get; set; }
        [Display(Name = "İçerik Resmi")]
        public string Image { get; set; }
        [Display(Name = "İçerik Tarihi"), ScaffoldColumn(false)]
        public System.DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Kategorisi")]
        public virtual Category Category { get; set; }
    }
}
