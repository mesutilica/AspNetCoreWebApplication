using System;
using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class Contact : IEntity
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
        [Display(Name = "Mesajınız"), Required]
        public string Message { get; set; }
        [Display(Name = "Mesaj Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
    }
}
