using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("estados");

            HasKey(t => t.EstadoId);

            Property(t => t.EstadoId)
                .IsRequired()
                .HasColumnName("estado_id");

            Property(t => t.Nome)
                .HasColumnName("nome");
        }
    }
}