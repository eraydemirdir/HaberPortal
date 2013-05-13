using HaberPortal.Data.DbContextMapping;
using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortal.Data.Context
{
    public class HaberPortalDbContext : DbContext
    {
        public HaberPortalDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new SeedHaberPortalDbContext());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Etiket> Etiket { get; set; }
        public DbSet<Galeri> Galeri { get; set; }
        public DbSet<Haber> Haber { get; set; }
        public DbSet<HaberTipi> HaberTipi { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Resim> Resim { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<HaberPozisyon> HaberPozisyon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HaberEtiketMapping());
            modelBuilder.Configurations.Add(new KullaniciMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class SeedHaberPortalDbContext : CreateDatabaseIfNotExists<HaberPortalDbContext>
    {
        protected override void Seed(HaberPortalDbContext context)
        {
            Kullanici kullanici = new Kullanici { Ad = "Admin", Sifre = "Admin", Eposta = "admin@gmail.com" };

            List<Rol> roller = new List<Rol>
            {
                new Rol { Ad = "Admin" },
                new Rol { Ad = "Moderator" },
                new Rol { Ad = "Editor" },
                new Rol { Ad = "Yazar" }
            };

            // roller
            foreach (var item in roller)
            {
                kullanici.Roller.Add(item);
            }

            // haber tipleri
            context.HaberTipi.Add(new HaberTipi { Ad = "Haber" });
            context.HaberTipi.Add(new HaberTipi { Ad = "Köşe Yazısı" });

            // haber posizyonları
            context.HaberPozisyon.Add(new HaberPozisyon { Ad = "Vitrin Orta", Id = 1 });
            context.HaberPozisyon.Add(new HaberPozisyon { Ad = "Vitrin Sol", Id = 2 });
            context.HaberPozisyon.Add(new HaberPozisyon { Ad = "Vitrin Sağ", Id = 3 });
            context.HaberPozisyon.Add(new HaberPozisyon { Ad = "Son Dakika", Id = 4 });
            context.HaberPozisyon.Add(new HaberPozisyon { Ad = "Köşe Yazısı", Id = 5 });
            context.HaberPozisyon.Add(new HaberPozisyon { Ad = "Standart", Id = 6 });

            // kategoriler
            context.Kategori.Add(new Kategori { Ad = "Gündem" });
            context.Kategori.Add(new Kategori { Ad = "Ekonomi" });
            context.Kategori.Add(new Kategori { Ad = "Spor" });
            context.Kategori.Add(new Kategori { Ad = "Eğitim" });
            context.Kategori.Add(new Kategori { Ad = "Dünya" });
            context.Kategori.Add(new Kategori { Ad = "Sağlık" });
            context.Kategori.Add(new Kategori { Ad = "Kültür" });
            context.Kategori.Add(new Kategori { Ad = "Teknoloji" });
            context.Kategori.Add(new Kategori { Ad = "Politika" });
            context.Kategori.Add(new Kategori { Ad = "Magazin" });
            context.Kategori.Add(new Kategori { Ad = "Finans" });
            context.Kategori.Add(new Kategori { Ad = "Emlak" });
            context.Kategori.Add(new Kategori { Ad = "Otomobil" });
            context.Kategori.Add(new Kategori { Ad = "Alışveriş" });
            context.Kategori.Add(new Kategori { Ad = "Tv Rehberi" });
            context.Kategori.Add(new Kategori { Ad = "Medya" });
            context.Kategori.Add(new Kategori { Ad = "Hava Durumu" });
            context.Kategori.Add(new Kategori { Ad = "Kadın" });
            context.Kategori.Add(new Kategori { Ad = "Yemek" });
            context.Kategori.Add(new Kategori { Ad = "Oyun" });

            // kullanıcı
            context.Kullanici.Add(kullanici);

            // örnek etiketler
            context.Etiket.Add(new Etiket { Ad = "haber" });
            context.Etiket.Add(new Etiket { Ad = "yazılım" });
            context.Etiket.Add(new Etiket { Ad = "bilişim" });
            context.Etiket.Add(new Etiket { Ad = "gündem" });
            context.Etiket.Add(new Etiket { Ad = "istanbul" });
            context.Etiket.Add(new Etiket { Ad = "iç politika" });
            context.Etiket.Add(new Etiket { Ad = "başbakan" });
            context.Etiket.Add(new Etiket { Ad = "ekonomi" });
            context.Etiket.Add(new Etiket { Ad = "enerji" });

            base.Seed(context);
        }
    }
}
