using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace HaberPortal.Web.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        private HaberPortalDbContext db;
        private KategoriServis kategoriServis;

        public KategoriController()
        {
            this.db = new HaberPortalDbContext();
            this.kategoriServis = new KategoriServis(db);
        }

        //
        // GET: /Admin/Kategori/

        public ActionResult Kategoriler()
        {
            return View();
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            try
            {
                kategoriServis.KategoriVarmi(kategori.Ad);
                kategoriServis.KategoriEkle(kategori);

                return RedirectToAction("Kategoriler");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(kategori);
        }

        public ActionResult KategoriDuzenle(int id)
        {
            var kategori = db.Kategori.Find(id);
            return View(kategori);
        }

        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori kategori)
        {
            try
            {
                kategoriServis.KategoriDuzenle(kategori);

                return RedirectToAction("Kategoriler");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            kategoriServis.KategoriSil(id);
            return RedirectToAction("Kategoriler");
        }

        public ActionResult KategorilerJson(int page, int rows, string sort, string order)
        {
            var kategoriler = kategoriServis.Kategoriler();

            int pageIndex = page - 1;
            int pageSize = rows;
            int totalRecords = kategoriler.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = new
            {
                total = totalRecords,
                rows = kategoriler.Select(x => new
                {
                    Id = x.Id,
                    Ad = x.Ad,
                    Aciklama = x.Aciklama
                })
                  .AsQueryable()
                  .OrderBy(sort + " " + order)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToList()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
