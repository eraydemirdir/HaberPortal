using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortal.Data.DbContextMapping
{
    public class KullaniciMapping : EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMapping()
        {
            // kullanici-rol ara tablosu oluşturma
            HasMany(h => h.Roller).
            WithMany(e => e.Kullanicilar).
            Map(
                m =>
                {
                    m.MapLeftKey("KullaniciId");
                    m.MapRightKey("RolId");
                    m.ToTable("KullaniciRol");
                }
            );

            // kullanıcı-yorum ayarı. yorum tablosu
            // hem haber tablosuna hemde kullanıcı tablosuna
            // bağlı. varsayılan olarak delete-on-cascade
            // tanımlı oldugundan, kullanıcı silindiginde mi
            // yoksa haber silinde mi yorumlar silinecek onun 
            // ayarı. kullanıcı silinince yorum kalsın diyoruz.
            HasMany(x => x.Yorumlar).
            WithRequired(x => x.Kullanici).
            HasForeignKey(x => x.KullaniciId).
            WillCascadeOnDelete(false);
        }
    }
}
