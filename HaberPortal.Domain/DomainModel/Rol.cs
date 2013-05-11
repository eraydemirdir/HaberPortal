using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Rol")]
    public class Rol
    {
        public Rol()
        {
            this.Kullanicilar = new HashSet<Kullanici>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Rol")]
        public string Ad { get; set; }

        public virtual ICollection<Kullanici> Kullanicilar { get; set; }
    }
}
