using HaberPortal.Domain.DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HaberPortal.Web.Areas.Admin.ViewModels
{
    public class HaberViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(150, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(300, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "İçerik")]
        public string Icerik { get; set; }

        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Kaynak")]
        public string Kaynak { get; set; }

        [Display(Name = "Yayında?")]
        public bool Yayinda { get { return true; } set { } }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Haber Tipi")]
        public int HaberTipId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Haber Pozisyon")]
        public int HaberPozisyonId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Yazar")]
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        [Display(Name = "Etiketler")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int[] SecilenEtiketler { get; set; }

        [Display(Name = "Haber Resim")]
        public HttpPostedFileBase Resim { get; set; }

        [Display(Name = "Mevcut Resim")]
        public string KucukResim { get; set; }

        public IEnumerable<Kategori> Kategoriler { get; set; }
        public IEnumerable<Kullanici> Kullanicilar { get; set; }
        public IEnumerable<HaberTipi> HaberTipleri { get; set; }
        public IEnumerable<Etiket> Etiketler { get; set; }
        public IEnumerable<HaberPozisyon> HaberPozisyon { get; set; }
    }
}