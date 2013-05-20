using HaberPortal.Data.Context;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HaberPortal.Core.Services
{
    public class RolServis
    {
        private HaberPortalDbContext db;

        public RolServis(HaberPortalDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Rol> Roller()
        {
            return db.Rol;
        }

        public int RolEkle(Rol rol)
        {
            db.Rol.Add(rol);
            return db.SaveChanges();
        }

        public Rol RolBul(int id)
        {
            return db.Rol.Find(id);
        }

        public void RolDuzenle(Rol rol)
        {
            db.Entry(rol).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool RolSil(int id)
        {
            bool silmeBasarili = false;
            var rol = db.Rol.Find(id);
            try
            {
                db.Rol.Remove(rol);
                db.SaveChanges();
                silmeBasarili = true;
            }
            catch (Exception ex)
            {

            }

            return silmeBasarili;
        }

        public void KullaniciyaRollerEkle(int userId, List<Rol> roller)
        {
            var kullanici = db.Kullanici.Find(userId);
            kullanici.Roller.Clear();
            roller.ForEach(x => kullanici.Roller.Add(db.Rol.Find(x.Id)));
            db.SaveChanges();
        }
    }
}
