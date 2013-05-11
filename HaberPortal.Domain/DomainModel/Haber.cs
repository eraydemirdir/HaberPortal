using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberPortal.Domain.DomainModel
{
    [Table("Haber")]
    public class Haber
    {
        public Haber()
        {
            this.Galeriler = new HashSet<Galeri>();
            this.Yorumlar = new HashSet<Yorum>();
            this.Etiketler = new HashSet<Etiket>();
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string Baslik { get; set; }

        [StringLength(300)]
        public string Aciklama { get; set; }

        public string Icerik { get; set; }

        [StringLength(500)]
        public string TumEtiketler { get; set; }

        public Nullable<DateTime> OlusturmaTarihi { get; set; }
        public Nullable<DateTime> DegistirmeTarihi { get; set; }
        public Nullable<DateTime> YayinlanmaTarihi { get; set; }
        public int DegistirmeKullanici { get; set; }
        public int YayinlamaKullanici { get; set; }
        public int OkunmaSayisi { get; set; }
        public int YorumSayisi { get; set; }

        [StringLength(50)]
        public string Kaynak { get; set; }

        public bool Yayinda { get; set; }

        [StringLength(250)]
        public string OrjinalProfilResim { get; set; }

        [StringLength(250)]
        public string BuyukProfilResim { get; set; }

        [StringLength(250)]
        public string KucukProfilResim { get; set; }

        public int HaberTipId { get; set; }
        public int KullaniciId { get; set; }
        public int KategoriId { get; set; }
        public int HaberPozisyonId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }

        [ForeignKey("HaberTipId")]
        public virtual HaberTipi HaberTipi { get; set; }

        [ForeignKey("HaberPozisyonId")]
        public virtual HaberPozisyon HaberPozisyon { get; set; }

        public virtual ICollection<Galeri> Galeriler { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
        public virtual ICollection<Etiket> Etiketler { get; set; }
    }
}
