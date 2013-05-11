using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Resim")]
    public class Resim
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string Ad { get; set; }

        [ScaffoldColumn(false)]
        public string Uzanti { get; set; }

        [ScaffoldColumn(false)]
        public int Boyut { get; set; }

        [ScaffoldColumn(false)]
        public string OrjinalResim { get; set; }

        [ScaffoldColumn(false)]
        public string BuyukResim { get; set; }

        [ScaffoldColumn(false)]
        public string KucukResim { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Galeri")]
        public int GaleriId { get; set; }

        [ForeignKey("GaleriId")]
        public virtual Galeri Galeri { get; set; }
    }
}
