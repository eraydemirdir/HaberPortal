using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
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
    }
}
