using HaberPortal.Domain.DomainModel;
using HaberPortal.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberPortal.Web.ModelMapping
{
    public static class ViewModelToModel
    {
        public static Haber HaberViewModelToHaber(HaberViewModel model, Haber haber)
        {
            int kullaniciId = model.KullaniciId;

            haber.Id = model.Id;
            haber.Aciklama = model.Aciklama;
            haber.Baslik = model.Baslik;
            haber.HaberTipId = model.HaberTipId;
            haber.Icerik = model.Icerik;
            haber.KategoriId = model.KategoriId;
            haber.Kaynak = model.Kaynak;
            haber.Yayinda = model.Yayinda;
            haber.DegistirmeKullanici = kullaniciId;
            haber.YayinlamaKullanici = kullaniciId;
            haber.KullaniciId = kullaniciId;
            haber.HaberPozisyonId = model.HaberPozisyonId;

            return haber;
        }

        public static Galeri GaleriViewModelToGaleri(GaleriViewModel model, Galeri galeri)
        {
            galeri.Ad = model.Ad;
            galeri.HaberId = model.HaberId;

            return galeri;
        }

        public static Kullanici KullaniciViewModelToKullanici(KullaniciViewModel model, Kullanici kullanici)
        {
            kullanici.Ad = model.Ad;
            kullanici.Eposta = model.Eposta;
            kullanici.Sifre = model.Sifre;

            return kullanici;
        }
    }
}