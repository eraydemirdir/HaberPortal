using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HaberPortal.Core.Services
{
    public class EtiketServis
    {
        private HaberPortalDbContext db;

        public EtiketServis(HaberPortalDbContext db)
        {
            this.db = db;
        }

        public Etiket EtiketBul(int id)
        {
            return db.Etiket.Find(id);
        }

        // verilen id lere sahip etiketleri getir
        public List<Etiket> Etiketler(int[] ids)
        {
            return db.Etiket
                .Where(x => ids.Contains(x.Id))
                .ToList();
        }

        public bool EtiketSil(int id)
        {
            bool silmeBasarili = false;
            var etiket = db.Etiket.Find(id);
            try
            {
                db.Etiket.Remove(etiket);
                db.SaveChanges();
                silmeBasarili = true;
            }
            catch (Exception ex)
            {

            }

            return silmeBasarili;
        }

        public int EtiketEkle(Etiket etiket)
        {
            db.Etiket.Add(etiket);
            return db.SaveChanges();
        }

        public void EtiketDuzenle(Etiket etiket)
        {
            db.Entry(etiket).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Etiket> Etiketler()
        {
            return db.Etiket.ToList();
        }
    }
}
