using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortal.Web.Controllers
{
    public class YazarController : Controller
    {
        private HaberPortalDbContext db;
        private KullaniciServis yazarServis;

        public YazarController()
        {
            this.db = new HaberPortalDbContext();
        }

        //
        // GET: /Yazar/

        public ActionResult Yazarlar()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
