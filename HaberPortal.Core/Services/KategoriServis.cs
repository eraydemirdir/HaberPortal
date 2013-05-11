using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace HaberPortal.Core.Services
{
    public class KategoriServis
    {
        private HaberPortalDbContext db;

        public KategoriServis(HaberPortalDbContext db)
        {
            this.db = db;
        }

        public List<Kategori> Kategoriler()
        {
            return db.Kategori.ToList();
        }

        public int KategoriEkle(Kategori kategori)
        {
            db.Kategori.Add(kategori);
            return db.SaveChanges();
        }

        public void KategoriDuzenle(Kategori kategori)
        {
            db.Entry(kategori).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool KategoriVarmi(string ad)
        {
            bool varmi = db.Kategori
                .Any(x => x.Ad.Trim().ToLower() == ad.Trim().ToLower());

            if (varmi)
            {
                throw new Exception("Eklemeye çalıştığınız kategori sistemde zaten mevcut!");
            }

            return varmi;
        }

        public bool KategoriSil(int id)
        {
            var silmeBasarilimi = false;
            var kategori = db.Kategori.Find(id);
            try
            {
                db.Kategori.Remove(kategori);
                db.SaveChanges();
                silmeBasarilimi = true;
            }
            catch (Exception ex)
            {
                silmeBasarilimi = false;
            }

            return silmeBasarilimi;
        }


    }
}
