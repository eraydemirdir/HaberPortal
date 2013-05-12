using HaberPortal.Core.Managers;
using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using HaberPortal.Web.Areas.Admin.ViewModels;
using HaberPortal.Web.ModelMapping;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace HaberPortal.Web.Areas.Admin.Controllers
{
    public class HaberController : Controller
    {
        private HaberPortalDbContext db;
        private HaberServis haberServis;
        private EtiketServis etiketServis;
        private KategoriServis kategoriServis;
        private KullaniciServis kullaniciServis;

        public HaberController()
        {
            this.db = new HaberPortalDbContext();
            this.haberServis = new HaberServis(db);
            this.etiketServis = new EtiketServis(db);
            this.kategoriServis = new KategoriServis(db);
            this.kullaniciServis = new KullaniciServis(db);
        }

        //
        // GET: /Admin/Haber/

        public ActionResult Haberler()
        {
            return View();
        }

        public ActionResult HaberEkle()
        {
            // dropdownlist elemanlarını ilkleme
            var model = new HaberViewModel
            {
                Kategoriler = kategoriServis.Kategoriler(),
                Kullanicilar = kullaniciServis.Kullanicilar(),
                HaberTipleri = haberServis.HaberTipleri(),
                Etiketler = etiketServis.Etiketler(),
                HaberPozisyon = haberServis.HaberPozisyonlari()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HaberEkle(HaberViewModel model)
        {
            try
            {
                Haber haber = new Haber();
                haber = ViewModelToModel.HaberViewModelToHaber(model, haber);
                var dosya = model.Resim;
                var etiketler = etiketServis.Etiketler(model.SecilenEtiketler);

                if (dosya != null && dosya.ContentLength > 0)
                {
                    // resmin ismini değiştir.
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(dosya.FileName);

                    // dosya dizinlerinin yollarını oluştur.
                    var orijinalResimDizin = Server.MapPath("~/Images/uploads/Haber");
                    var buyukResimDizin = Server.MapPath("~/Images/uploads/Haber/Buyuk");
                    var kucukResimDizin = Server.MapPath("~/Images/uploads/Haber/Kucuk");

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
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(orijinalResimDizin, fileName)), new Size(600, 600), buyukResimDizin, fileName);
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(orijinalResimDizin, fileName)), new Size(200, 200), kucukResimDizin, fileName);

                    haber.OrjinalProfilResim = Path.Combine("Images/uploads/Haber/", fileName);
                    haber.BuyukProfilResim = Path.Combine("Images/uploads/Haber/Buyuk/", fileName);
                    haber.KucukProfilResim = Path.Combine("Images/uploads/Haber/Kucuk/", fileName);
                }

                haber.DegistirmeTarihi = DateTime.Now;
                haber.OkunmaSayisi = 0;
                haber.OlusturmaTarihi = DateTime.Now;
                haber.YayinlanmaTarihi = DateTime.Now;
                haber.YorumSayisi = 0;
                haber.TumEtiketler = string.Join(", ", etiketler.Select(x => x.Ad));
                etiketler.ForEach(x => haber.Etiketler.Add(x));

                haberServis.HaberEkle(haber);

                return RedirectToAction("Haberler");
            }
            catch (Exception ex)
            {
                // haber kaydı başarısızsa
                // dropdownlist elemanlarını
                // tekrar ilkleme
                model = new HaberViewModel
                {
                    Kategoriler = kategoriServis.Kategoriler(),
                    Kullanicilar = kullaniciServis.Kullanicilar(),
                    HaberTipleri = haberServis.HaberTipleri(),
                    Etiketler = etiketServis.Etiketler(),
                    HaberPozisyon = haberServis.HaberPozisyonlari()
                };
            }

            return View(model);
        }

        public ActionResult HaberDuzenle(int id)
        {
            var haber = haberServis.HaberBul(id);
            HaberViewModel model = ModelToViewModel.HaberToHaberViewModel(haber);

            // dropdownlistleri ilkleme
            model.Kategoriler = kategoriServis.Kategoriler();
            model.Kullanicilar = kullaniciServis.Kullanicilar();
            model.HaberTipleri = haberServis.HaberTipleri();
            model.Etiketler = etiketServis.Etiketler();
            model.HaberPozisyon = haberServis.HaberPozisyonlari();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HaberDuzenle(HaberViewModel model)
        {
            try
            {
                var haber = haberServis.HaberBul(model.Id);
                haber = ViewModelToModel.HaberViewModelToHaber(model, haber);
                var dosya = model.Resim;
                var etiketler = etiketServis.Etiketler(model.SecilenEtiketler);

                if (dosya != null && dosya.ContentLength > 0)
                {
                    // resmin ismini değiştir.
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(dosya.FileName);

                    // dosya dizinlerinin yollarını oluştur.
                    var orijinalResimDizin = Server.MapPath("~/Images/uploads/Haber");
                    var buyukResimDizin = Server.MapPath("~/Images/uploads/Haber/Buyuk");
                    var kucukResimDizin = Server.MapPath("~/Images/uploads/Haber/Kucuk");

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
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(orijinalResimDizin, fileName)), new Size(600, 600), buyukResimDizin, fileName);
                    ImageManager.SaveResizedImage(Image.FromFile(Path.Combine(orijinalResimDizin, fileName)), new Size(200, 200), kucukResimDizin, fileName);

                    haber.OrjinalProfilResim = Path.Combine("Images/uploads/Haber/", fileName);
                    haber.BuyukProfilResim = Path.Combine("Images/uploads/Haber/Buyuk/", fileName);
                    haber.KucukProfilResim = Path.Combine("Images/uploads/Haber/Kucuk/", fileName);
                }

                haber.DegistirmeTarihi = DateTime.Now;
                haber.OkunmaSayisi = 0;
                haber.OlusturmaTarihi = DateTime.Now;
                haber.YayinlanmaTarihi = DateTime.Now;
                haber.YorumSayisi = 0;
                haber.TumEtiketler = string.Join(", ", etiketler.Select(x => x.Ad));
                haber.Etiketler.Clear();
                etiketler.ForEach(x => haber.Etiketler.Add(x));

                haberServis.HaberDuzenle(haber);

                return RedirectToAction("Haberler");
            }
            catch (Exception ex)
            {
                // haber kaydı başarısızsa
                // dropdownlist elemanlarını
                // tekrar ilkleme
                model = new HaberViewModel
                {
                    Kategoriler = kategoriServis.Kategoriler(),
                    Kullanicilar = kullaniciServis.Kullanicilar(),
                    HaberTipleri = haberServis.HaberTipleri(),
                    Etiketler = etiketServis.Etiketler(),
                    HaberPozisyon = haberServis.HaberPozisyonlari()
                };
            }

            return View(model);
        }

        public ActionResult HaberDetay(int id)
        {
            var haber = haberServis.HaberBul(id);

            return View(haber);
        }

        public ActionResult HaberlerJson(int page, int rows, string sort, string order)
        {
            var haberler = haberServis.Haberler();

            int pageIndex = page - 1;
            int pageSize = rows;
            int totalRecords = haberler.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = new
            {
                total = totalRecords,
                rows = haberler.Select(x => new
                  {
                      Id = x.Id,
                      Baslik = x.Baslik,
                      Aciklama = x.Aciklama,
                      Kategori = x.Kategori.Ad,
                      HaberTipi = x.HaberTipi.Ad,
                      Yazar = x.Kullanici.Ad,
                      KucukResim = x.KucukProfilResim,
                      Yayinda = x.Yayinda,
                      OlusturmaTarihi = x.OlusturmaTarihi
                  })
                  .AsQueryable()
                  .OrderBy(sort + " " + order)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToList()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HaberSil(int id)
        {
            haberServis.HaberSil(id);
            return RedirectToAction("Haberler");
        }

        public ActionResult HaberDurumGuncelle(int id, bool durum)
        {
            haberServis.HaberDurumGuncelle(id, durum);

            return RedirectToAction("Haberler");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
