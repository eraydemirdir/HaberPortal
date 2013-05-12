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

        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        [StringLength(150)]
        public string Eposta { get; set; }

        public string OrjinalProfilResim { get; set; }
        public string KucukProfilResim { get; set; }
        public Nullable<DateTime> KayitTarihi { get; set; }

        public virtual ICollection<Rol> Roller { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
    }
}
