using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using System.Web.Mvc;
using System.Linq;

namespace HaberPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private HaberPortalDbContext db;
        private HaberServis haberServis;

        public HomeController()
        {
            this.db = new HaberPortalDbContext();
            this.haberServis = new HaberServis(db);
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HaberDetay(int id)
        {
            var haber = haberServis.HaberBul(id);
            return View(haber);
        }

        public ActionResult KoseYazisiDetay(int id)
        {
            var haber = haberServis.HaberBul(id);
            return View(haber);
        }

        public ActionResult VitrinSol()
        {
            // pozisyon id = 3 olan haberler solda görünür
            var haberler = haberServis.HaberlerPozisyonaGore(2)
                .OrderByDescending(x => x.OlusturmaTarihi)
                .Where(x => x.Yayinda)
                .Take(3);

            return PartialView(haberler);
        }

        public ActionResult VitrinOrta()
        {
            // pozisyon id = 3 olan haberler ortada (slider) görünür
            var haberler = haberServis.HaberlerPozisyonaGore(1)
                .OrderByDescending(x => x.OlusturmaTarihi)
                .Where(x => x.Yayinda)
                .Take(20);

            return PartialView(haberler);
        }

        public ActionResult VitrinSag()
        {
            // pozisyon id = 3 olan haberler sagda (köşe yazıları) görünür
            var haberler = haberServis.HaberlerPozisyonaGore(3)
                .OrderByDescending(x => x.OlusturmaTarihi)
                .Where(x => x.Yayinda)
                .Take(5);

            return PartialView(haberler);
        }

    }
}
