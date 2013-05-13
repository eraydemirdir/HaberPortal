using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Kategori")]
    public class Kategori
    {
        public Kategori()
        {
            this.Haberler = new HashSet<Haber>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Kategori")]
        public string Ad { get; set; }

        [StringLength(250, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        public string Aciklama { get; set; }

        public bool AnaSayfa { get; set; }
        public bool AnaMenu { get; set; }
        public int SiraNo { get; set; }

        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
