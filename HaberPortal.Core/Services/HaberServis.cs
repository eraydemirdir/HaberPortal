using HaberPortal.Core.Services;
using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using System.Data;

namespace HaberPortal.Core.Services
{
    public class HaberServis
    {
        private HaberPortalDbContext db;

        public HaberServis(HaberPortalDbContext db)
        {
            this.db = db;
        }

        public int HaberEkle(Haber haber)
        {
            db.Haber.Add(haber);
            return db.SaveChanges();
        }

        public void HaberDuzenle(Haber haber)
        {
            db.Entry(haber).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool HaberSil(int id)
        {
            var silmeBasarilimi = false;
            var haber = db.Haber.Find(id);
            try
            {
                db.Haber.Remove(haber);
                db.SaveChanges();
                silmeBasarilimi = true;
            }
            catch (Exception ex)
            {
                silmeBasarilimi = false;
            }

            return silmeBasarilimi;
        }

        public void HaberDurumGuncelle(int id, bool durum)
        {
            var haber = db.Haber.Find(id);
            haber.Yayinda = !durum;
            db.SaveChanges();
        }

        public List<Haber> Haberler(int haberTipId = 0)
        {
            // eğer haber id belirlenmemişse
            // tüm haberleri getir, aksi durumda
            // seçilen haber tipindeki haberleri getir.
            if (haberTipId == 0)
            {
                return db.Haber.ToList();
            }
            else
            {
                return db.Haber
                    .Where(x => x.HaberTipId == haberTipId)
                    .ToList();
            }
        }

        public List<Haber> HaberlerPozisyonaGore(int pozisyonId = 0)
        {
            // eğer haber id belirlenmemişse
            // tüm haberleri getir, aksi durumda
            // seçilen haber pozisyonundaki haberleri getir.
            if (pozisyonId == 0)
            {
                return db.Haber.ToList();
            }
            else
            {
                return db.Haber
                    .Where(x => x.HaberPozisyonId == pozisyonId)
                    .ToList();
            }
        }

        public Haber HaberBul(int id)
        {
            return db.Haber.Find(id);
        }

        public IEnumerable<HaberTipi> HaberTipleri()
        {
            return db.HaberTipi;
        }

        public IEnumerable<HaberPozisyon> HaberPozisyonlari()
        {
            return db.HaberPozisyon;
        }
    }
}
