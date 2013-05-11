using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;

namespace HaberPortal.Web.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        private HaberPortalDbContext db;
        private KullaniciServis kullaniciServis;

        public KullaniciController()
        {
            this.db = new HaberPortalDbContext();
            this.kullaniciServis = new KullaniciServis(db);
        }

        //
        // GET: /Admin/Kullanici/

        public ActionResult Kullanicilar()
        {
            return View();
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
