using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortal.Domain.DomainModel
{
    [Table("HaberTipi")]
    public class HaberTipi
    {
        public HaberTipi()
        {
            this.Haberler = new HashSet<Haber>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
