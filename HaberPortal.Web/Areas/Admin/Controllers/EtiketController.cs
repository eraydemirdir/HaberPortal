using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;

namespace HaberPortal.Web.Areas.Admin.Controllers
{
    public class EtiketController : Controller
    {
        private HaberPortalDbContext db;
        private EtiketServis etiketServis;

        public EtiketController()
        {
            this.db = new HaberPortalDbContext();
            this.etiketServis = new EtiketServis(db);
        }

        //
        // GET: /Admin/Etiket/

        public ActionResult Etiketler()
        {
            return View();
        }

        public ActionResult EtiketEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EtiketEkle(Etiket etiket)
        {
            try
            {
                etiketServis.EtiketEkle(etiket);
                return RedirectToAction("Etiketler");
            }
            catch (Exception ex)
            {

            }

            return View(etiket);
        }

        public ActionResult EtiketDuzenle(int id)
        {
            var etiket = etiketServis.EtiketBul(id);

            return View(etiket);
        }

        [HttpPost]
        public ActionResult EtiketDuzenle(Etiket etiket)
        {
            try
            {
                etiketServis.EtiketDuzenle(etiket);

                return RedirectToAction("Etiketler");
            }
            catch (Exception ex)
            {

            }

            return View(etiket);
        }

        public ActionResult EtiketSil(int id)
        {
            etiketServis.EtiketSil(id);
            return RedirectToAction("Etiketler");
        }

        public ActionResult EtiketlerJson(int page, int rows, string sort, string order)
        {
            var etiketler = etiketServis.Etiketler();

            int pageIndex = page - 1;
            int pageSize = rows;
            int totalRecords = etiketler.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = new
            {
                total = totalRecords,
                rows = etiketler.Select(x => new
                {
                    Id = x.Id,
                    Ad = x.Ad
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
