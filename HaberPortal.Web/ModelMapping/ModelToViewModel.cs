using HaberPortal.Domain.DomainModel;
using HaberPortal.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberPortal.Web.ModelMapping
{
    public static class ModelToViewModel
    {
        public static HaberViewModel HaberToHaberViewModel(Haber haber)
        {
            HaberViewModel model = new HaberViewModel();

            model.Aciklama = haber.Aciklama;
            model.Baslik = haber.Baslik;
            model.HaberTipId = haber.HaberTipId;
            model.Icerik = haber.Icerik;
            model.Id = haber.Id;
            model.KategoriId = haber.KategoriId;
            model.Kaynak = haber.Kaynak;
            model.KullaniciId = haber.KullaniciId;
            model.SecilenEtiketler = haber.Etiketler.Select(x => x.Id).ToArray();
            model.Yayinda = haber.Yayinda;
            model.KucukResim = haber.KucukProfilResim;
            model.HaberPozisyonId = haber.HaberPozisyonId;

            return model;
        }

        public static GaleriViewModel GaleriToGaleriViewModel(Galeri galeri)
        {
            GaleriViewModel model = new GaleriViewModel();

            model.Ad = galeri.Ad;
            model.HaberId = galeri.HaberId;
            model.Id = galeri.Id;

            return model;
        }

        public static KullaniciViewModel KullaniciToKullaniciViewModel(Kullanici kullanici)
        {
            KullaniciViewModel model = new KullaniciViewModel();

            model.Ad = kullanici.Ad;
            model.Eposta = kullanici.Eposta;
            model.Id = kullanici.Id;
            model.KucukResim = kullanici.KucukProfilResim;
            model.Sifre = kullanici.Sifre;

            return model;
        }
   }
}