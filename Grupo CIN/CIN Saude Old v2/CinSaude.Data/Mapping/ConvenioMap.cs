using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ConvenioMap : EntityTypeConfiguration<Convenio>
    {
        public ConvenioMap()
        {
            ToTable("convenios");

            HasKey(t => t.ConvenioId);

            Property(t => t.ConvenioId)
                .IsRequired()
                .HasColumnName("convenio_id");

            Property(t => t.Empresa)
                .HasColumnName("empresa");
        }
    }
}