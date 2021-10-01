using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız"), Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Soyadınız"), Required, StringLength(50)]
        public string Surname { get; set; }
        [EmailAddress, Required, StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Telefon"), StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Kullanıcı Adı"), StringLength(50)]
        public string Username { get; set; }
        [Display(Name = "Şifre"), Required, StringLength(150)]
        public string Password { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]//ScaffoldColumn kodu, otomatik sayfa oluşturma işleminde bu alan için crud kodu üretmemesini sağlar 
        public System.DateTime CreateDate { get; set; }
    }
}
