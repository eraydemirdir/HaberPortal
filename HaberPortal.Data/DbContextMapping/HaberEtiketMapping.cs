using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortal.Data.DbContextMapping
{
    public class HaberEtiketMapping : EntityTypeConfiguration<Haber>
    {
        public HaberEtiketMapping()
        {
            HasMany(h => h.Etiketler).
            WithMany(e => e.Haberler).
            Map(
                m =>
                {
                    m.MapLeftKey("HaberId");
                    m.MapRightKey("EtiketId");
                    m.ToTable("HaberEtiket");
                }
            );
        }
    }
}
