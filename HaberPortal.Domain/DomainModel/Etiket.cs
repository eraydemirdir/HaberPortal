using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Etiket")]
    public class Etiket
    {
        public Etiket()
        {
            this.Haberler = new HashSet<Haber>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Etiket")]
        public string Ad { get; set; }

        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
