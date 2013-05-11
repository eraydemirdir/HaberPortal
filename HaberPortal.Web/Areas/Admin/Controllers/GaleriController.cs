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
    public class GaleriController : Controller
    {
        private HaberPortalDbContext db;
        private GaleriServis galeriServis;
        private HaberServis haberServis;

        public GaleriController()
        {
            this.db = new HaberPortalDbContext();
            this.galeriServis = new GaleriServis(db);
            this.haberServis = new HaberServis(db);
        }

        //
        // GET: /Admin/Galeri/

        public ActionResult Galeriler()
        {
            return View();
        }

        public ActionResult GaleriEkle()
        {
            var model = new GaleriViewModel
            {
                Haberler = haberServis.Haberler()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GaleriEkle(GaleriViewModel model)
        {
            try
            {
                Galeri galeri = new Galeri();
                galeri = ViewModelToModel.GaleriViewModelToGaleri(model, galeri);

                foreach (var dosya in model.Resimler)
                {
                    // her döngüde seçilen galeri için resim oluştur
                    Resim resim = new Resim();

                    // resmin ismini değiştir.
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(dosya.FileName);

                    // dosya dizinlerinin yollarını oluştur.
                    var orijinalResimDizin = Server.MapPath("~/Images/uploads/Galeri");
                    var buyukResimDizin = Server.MapPath("~/Images/uploads/Galeri/Buyuk");
                    var kucukResimDizin = Server.MapPath("~/Images/uploads/Galeri/Kucuk");

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

                    // resimin özelliklerini belirle
                    resim.Ad = fileName;
                    resim.Boyut = dosya.ContentLength;
                    resim.Uzanti = dosya.ContentType;
                    resim.OrjinalResim = Path.Combine("Images/uploads/Galeri/", fileName);
                    resim.BuyukResim = Path.Combine("Images/uploads/Galeri/Buyuk/", fileName);
                    resim.KucukResim = Path.Combine("Images/uploads/Galeri/Kucuk/", fileName);

                    // resmi geleriye ekle
                    galeri.Resimler.Add(resim);
                }

                galeriServis.GaleriEkle(galeri);

                return RedirectToAction("Galeriler");
            }
            catch (Exception ex)
            {
                model.Haberler = haberServis.Haberler();
            }

            return View(model);
        }

        public ActionResult GaleriDuzenle(int id)
        {
            var galeri = galeriServis.GaleriBul(id);
            var model = ModelToViewModel.GaleriToGaleriViewModel(galeri);

            // dropdownlist ilkeleme
            model.Haberler = haberServis.Haberler();

            return View(model);
        }

        [HttpPost]
        public ActionResult GaleriDuzenle(GaleriViewModel model)
        {
            try
            {
                Galeri galeri = new Galeri();
                galeri = ViewModelToModel.GaleriViewModelToGaleri(model, galeri);

                foreach (var dosya in model.Resimler)
                {
                    // her döngüde seçilen galeri için resim oluştur
                    Resim resim = new Resim();

                    // resmin ismini değiştir.
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(dosya.FileName);

                    // dosya dizinlerinin yollarını oluştur.
                    var orijinalResimDizin = Server.MapPath("~/Images/uploads/Galeri");
                    var buyukResimDizin = Server.MapPath("~/Images/uploads/Galeri/Buyuk");
                    var kucukResimDizin = Server.MapPath("~/Images/uploads/Galeri/Kucuk");

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

                    // resimin özelliklerini belirle
                    resim.Ad = fileName;
                    resim.Boyut = dosya.ContentLength;
                    resim.Uzanti = dosya.ContentType;
                    resim.OrjinalResim = Path.Combine("Images/uploads/Galeri/", fileName);
                    resim.BuyukResim = Path.Combine("Images/uploads/Galeri/Buyuk/", fileName);
                    resim.KucukResim = Path.Combine("Images/uploads/Galeri/Kucuk/", fileName);

                    // resmi geleriye ekle
                    galeri.Resimler.Add(resim);
                }

                galeriServis.GaleriDuzenle(galeri);

                return RedirectToAction("Galeriler");
            }
            catch (Exception ex)
            {
                model.Haberler = haberServis.Haberler();
            }

            return View(model);
        }

        public ActionResult GaleriSil(int id)
        {
            galeriServis.GaleriSil(id);

            return RedirectToAction("Galeriler");
        }

        public ActionResult GalerilerJson(int page, int rows, string sort, string order)
        {
            var galeriler = galeriServis.Galeriler();

            int pageIndex = page - 1;
            int pageSize = rows;
            int totalRecords = galeriler.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = new
            {
                total = totalRecords,
                rows = galeriler.Select(x => new
                {
                    Id = x.Id,
                    Ad = x.Ad,
                    HaberBaslik = x.Haber.Baslik
                })
                  .AsQueryable()
                  .OrderBy(sort + " " + order)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToList()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GaleriResimler(int id)
        {
            var galeri = galeriServis.GaleriBul(id);
            ViewBag.Galeriler = new SelectList(db.Galeri, "Id", "Ad", id);

            return View(galeri);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
