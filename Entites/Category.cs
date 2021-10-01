using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Üst Kategorisi")]
        public int ParentId { get; set; }
        [Display(Name = "Kategori Adı"), Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Kategori Resmi")]
        public string Image { get; set; }
    }
}
