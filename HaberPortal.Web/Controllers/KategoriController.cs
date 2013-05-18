using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortal.Web.Controllers
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
        // GET: /Kategori/

        public ActionResult KategoriDetay(int id)
        {
            var kategori = kategoriServis.KategoriBul(id);
            return View(kategori);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
