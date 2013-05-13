using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("HaberPozisyon")]
    public class HaberPozisyon
    {
        public HaberPozisyon()
        {
            this.Haberler = new HashSet<Haber>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(250, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        public string Aciklama { get; set; }

        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
