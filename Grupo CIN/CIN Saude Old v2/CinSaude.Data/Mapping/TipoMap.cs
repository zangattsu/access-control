using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class TipoMap : EntityTypeConfiguration<Tipo>
    {
        public TipoMap()
        {
            ToTable("tipo_medicina");

            HasKey(t => t.TipoId);

            Property(t => t.TipoId)
                .IsRequired()
                .HasColumnName("tipo_id");

            Property(t => t.Descricao)
                .HasColumnName("descricao");
        }
    }
}