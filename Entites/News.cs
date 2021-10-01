using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class News : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Haber Adı"), Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Haber Açıklaması"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Haber Resmi")]
        public string Image { get; set; }
        [Display(Name = "Haber Tarihi"), ScaffoldColumn(false)]
        public System.DateTime CreateDate { get; set; }
    }
}
