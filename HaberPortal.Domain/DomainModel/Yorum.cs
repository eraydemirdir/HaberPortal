using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Yorum")]
    public class Yorum
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(500, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Yorum")]
        [DataType(DataType.MultilineText)]
        public string YorumMetin { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<DateTime> OlusturmaTarihi { get; set; }

        [ScaffoldColumn(false)]
        public bool Onayli { get { return false; } set {  } }

        [ScaffoldColumn(false)]
        public int KullaniciId { get; set; }

        [ScaffoldColumn(false)]
        public int HaberId { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }

        [ForeignKey("HaberId")]
        public virtual Haber Haber { get; set; }
    }
}
