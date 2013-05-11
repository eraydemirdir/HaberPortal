using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HaberPortal.Core.Services
{
    public class GaleriServis
    {
        private HaberPortalDbContext db;

        public GaleriServis(HaberPortalDbContext db)
        {
            this.db = db;
        }

        public List<Galeri> Galeriler()
        {
            return db.Galeri.ToList();
        }

        public int GaleriEkle(Galeri galeri)
        {
            db.Galeri.Add(galeri);
            return db.SaveChanges();
        }

        public void GaleriDuzenle(Galeri galeri)
        {
            db.Entry(galeri).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool GaleriSil(int id)
        {
            bool silmeBasarili = false;

            try
            {
                var galeri = db.Galeri.Find(id);
                db.SaveChanges();
                silmeBasarili = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Silme işlemi sırasında hata oluştu!");
            }

            return silmeBasarili;
        }

        public Galeri GaleriBul(int id)
        {
            return db.Galeri.Find(id);
        }
    }
}
