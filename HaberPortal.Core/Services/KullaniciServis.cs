using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortal.Core.Services
{
    public class KullaniciServis
    {
        private HaberPortalDbContext db;

        public KullaniciServis(HaberPortalDbContext db)
        {
            this.db = db;
        }

        public int KullaniciIdGetir(string KullaniciAdi)
        {
            return db.Kullanici.SingleOrDefault(x => x.Ad == KullaniciAdi).Id;
        }

        public IEnumerable<Kullanici> Kullanicilar()
        {
            return db.Kullanici;
        }

        public int KullaniciEkle(Kullanici kullanici)
        {
            db.Kullanici.Add(kullanici);
            return db.SaveChanges();
        }

        public Kullanici KullaniciBul(int id)
        {
            return db.Kullanici.Find(id);
        }

        public void KullaniciDuzenle(Kullanici kullanici)
        {
            db.Entry(kullanici).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
