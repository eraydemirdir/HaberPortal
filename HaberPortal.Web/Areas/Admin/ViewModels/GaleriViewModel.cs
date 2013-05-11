using HaberPortal.Domain.DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HaberPortal.Web.Areas.Admin.ViewModels
{
    public class GaleriViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Galeri Adı")]
        public string Ad { get; set; }

        [Display(Name="Haber")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int HaberId { get; set; }

        public IEnumerable<Haber> Haberler { get; set; }
        public IEnumerable<HttpPostedFileBase> Resimler { get; set; }
    }
}