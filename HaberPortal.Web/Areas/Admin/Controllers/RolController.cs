using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;
using HaberPortal.Domain.DomainModel;

namespace HaberPortal.Web.Areas.Admin.Controllers
{
    public class RolController : Controller
    {
        private HaberPortalDbContext db;
        private RolServis rolServis;

        public RolController()
        {
            this.db = new HaberPortalDbContext();
            this.rolServis = new RolServis(db);
        }

        //
        // GET: /Admin/Rol/

        public ActionResult Roller()
        {
            return View();
        }

        public ActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RolEkle(Rol rol)
        {
            try
            {
                rolServis.RolEkle(rol);
                return RedirectToAction("Roller");
            }
            catch (Exception ex)
            {
            }

            return View(rol);
        }

        public ActionResult RolDuzenle(int id)
        {
            var rol = rolServis.RolBul(id);
            return View(rol);
        }

        [HttpPost]
        public ActionResult RolDuzenle(Rol rol)
        {
            try
            {
                rolServis.RolDuzenle(rol);

                return RedirectToAction("Roller");
            }
            catch (Exception ex)
            {
            }

            return View(rol);
        }

        public ActionResult RolSil(int id)
        {
            rolServis.RolSil(id);

            return RedirectToAction("Roller");
        }

        public ActionResult RollerJson(int page, int rows, string sort, string order)
        {
            var roller = rolServis.Roller();

            int pageIndex = page - 1;
            int pageSize = rows;
            int totalRecords = roller.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = new
            {
                total = totalRecords,
                rows = roller.Select(x => new
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
