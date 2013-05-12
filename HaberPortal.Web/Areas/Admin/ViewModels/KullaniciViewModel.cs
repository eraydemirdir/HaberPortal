﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HaberPortal.Web.Areas.Admin.ViewModels
{
    public class KullaniciViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [StringLength(150, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Eposta")]
        [EmailAddress(ErrorMessage="Eposta adresi geçersiz!")]
        public string Eposta { get; set; }

        [Display(Name = "Kullanıcı Resim")]
        public HttpPostedFileBase Resim { get; set; }

        [Display(Name = "Mevcut Resim")]
        public string KucukResim { get; set; }
    }
}