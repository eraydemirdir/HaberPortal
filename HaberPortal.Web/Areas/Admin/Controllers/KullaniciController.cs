﻿using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;
using HaberPortal.Domain.DomainModel;
using HaberPortal.Web.ModelMapping;
using System.IO;
using HaberPortal.Core.Managers;
using System.Drawing;
using HaberPortal.Web.Areas.Admin.ViewModels;
using System.Collections.Generic;

namespace HaberPortal.Web.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        private HaberPortalDbContext db;
        private KullaniciServis kullaniciServis;
        private RolServis rolServis;

        public KullaniciController()
        {
            this.db = new HaberPortalDbContext();
            this.kullaniciServis = new KullaniciServis(db);
            this.rolServis = new RolServis(db);
        }

        //
        // GET: /Admin/Kullanici/

        public ActionResult Kullanicilar()
        {
            return View();
        }

        public ActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciEkle(KullaniciViewModel model)
        {
            try
            {
                Kullanici kullanici = new Kullanici();
                kullanici = ViewModelToModel.KullaniciViewModelToKullanici(model, kullanici);
                var dosya = model.Resim;

                if (dosya != null && dosya.ContentLength > 0)
                {
                    // resmin ismini değiştir.
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(dosya.FileName);

                    // dosya dizinlerinin yollarını oluştur.
                    var orijinalResimDizin = Server.MapPath("~/Images/uploads/Kullanici");
                    var buyukResimDizin = Server.MapPath("~/Images/uploads/Kullanici/Buyuk");
                    var kucukResimDizin = Server.MapPath("~/Images/uploads/Kullanici/Kucuk");

                    // dizin yoksa oluştur.
                    if (!Directory.Exists(orijinalResimDizin))
                    {
                        Directory.CreateDirectory(orijinalResimDizin);
                        Directory.CreateDirectory(buyukResimDizin);
                        Directory.CreateDirectory(kucukResimDizin);
                    }

                    // dosyayı kaydet
                    dosya.SaveAs(Path.Combine(orijinalResimDizin, fileName));

                    // resimleri farklı boyutlarda kaydet.
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(orijinalResimDizin, fileName)), new Size(200, 200), kucukResimDizin, fileName);

                    kullanici.OrjinalProfilResim = Path.Combine("Images/uploads/Kullanici/", fileName);
                    kullanici.KucukProfilResim = Path.Combine("Images/uploads/Kullanici/Kucuk/", fileName);
                    kullanici.KayitTarihi = DateTime.Now;
                }

                kullaniciServis.KullaniciEkle(kullanici);

                return RedirectToAction("Kullanicilar");
            }
            catch (Exception ex)
            {

            }

            return View(model);
        }

        public ActionResult KullaniciDuzenle(int id)
        {
            var kullanici = kullaniciServis.KullaniciBul(id);
            var model = ModelToViewModel.KullaniciToKullaniciViewModel(kullanici);
            return View(model);
        }

        [HttpPost]
        public ActionResult KullaniciDuzenle(KullaniciViewModel model)
        {
            try
            {
                Kullanici kullanici = kullaniciServis.KullaniciBul(model.Id);
                kullanici = ViewModelToModel.KullaniciViewModelToKullanici(model, kullanici);
                var dosya = model.Resim;

                if (dosya != null && dosya.ContentLength > 0)
                {
                    // resmin ismini değiştir.
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(dosya.FileName);

                    // dosya dizinlerinin yollarını oluştur.
                    var orijinalResimDizin = Server.MapPath("~/Images/uploads/Kullanici");
                    var buyukResimDizin = Server.MapPath("~/Images/uploads/Kullanici/Buyuk");
                    var kucukResimDizin = Server.MapPath("~/Images/uploads/Kullanici/Kucuk");

                    // dizin yoksa oluştur.
                    if (!Directory.Exists(orijinalResimDizin))
                    {
                        Directory.CreateDirectory(orijinalResimDizin);
                        Directory.CreateDirectory(buyukResimDizin);
                        Directory.CreateDirectory(kucukResimDizin);
                    }

                    // dosyayı kaydet
                    dosya.SaveAs(Path.Combine(orijinalResimDizin, fileName));

                    // resimleri farklı boyutlarda kaydet.
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(orijinalResimDizin, fileName)), new Size(200, 200), kucukResimDizin, fileName);

                    kullanici.OrjinalProfilResim = Path.Combine("Images/uploads/Kullanici/", fileName);
                    kullanici.KucukProfilResim = Path.Combine("Images/uploads/Kullanici/Kucuk/", fileName);
                    kullanici.KayitTarihi = DateTime.Now;
                }

                kullaniciServis.KullaniciDuzenle(kullanici);

                return RedirectToAction("Kullanicilar");
            }
            catch (Exception ex)
            {

            }

            return View(model);
        }

        public ActionResult KullanicilarJson(int page, int rows, string sort, string order)
        {
            var kullanicilar = kullaniciServis.Kullanicilar();

            int pageIndex = page - 1;
            int pageSize = rows;
            int totalRecords = kullanicilar.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = new
            {
                total = totalRecords,
                rows = kullanicilar.Select(x => new
                {
                    Id = x.Id,
                    Ad = x.Ad,
                    Eposta = x.Eposta
                })
                  .AsQueryable()
                  .OrderBy(sort + " " + order)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToList()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult KullaniciRolEkle(int id)
        {
            var kullanici = kullaniciServis.KullaniciBul(id);
            var roller = rolServis.Roller();

            KullaniciRolViewModel model = new KullaniciRolViewModel();
            model.KullaniciId = kullanici.Id;

            foreach (var rol in roller)
            {
                model.Roller.Add(new RolViewModel
                {
                    RoleSahip = kullanici.Roller.Any(r => r.Id == rol.Id),
                    Id = rol.Id,
                    RolAdi = rol.Ad
                });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult KullaniciRolEkle(KullaniciRolViewModel model)
        {
            List<Rol> roller = model.Roller
                .Where(r => r.RoleSahip)
                .Select(r => new Rol { Id = r.Id, Ad = r.RolAdi })
                .ToList();

            rolServis.KullaniciyaRollerEkle(model.KullaniciId, roller);

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
