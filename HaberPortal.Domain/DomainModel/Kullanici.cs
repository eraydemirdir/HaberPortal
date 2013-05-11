using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Kullanici")]
    public class Kullanici
    {
        public Kullanici()
        {
            this.Roller = new HashSet<Rol>();
            this.Yorumlar = new HashSet<Yorum>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(150, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Eposta")]
        public string Eposta { get; set; }

        [ScaffoldColumn(false)]
        public string OrjinalProfilResim { get; set; }

        [ScaffoldColumn(false)]
        public string KucukProfilResim { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<DateTime> KayitTarihi { get; set; }

        public virtual ICollection<Rol> Roller { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
    }
}
