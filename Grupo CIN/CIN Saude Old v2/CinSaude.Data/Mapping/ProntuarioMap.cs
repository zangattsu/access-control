using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ProntuarioMap : EntityTypeConfiguration<Prontuario>
    {
        public ProntuarioMap()
        {
            ToTable("prontuario");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .IsRequired()
                .HasColumnName("prontuario_id");

            Property(t => t.ConsultaId)
                .IsRequired()
                .HasColumnName("consulta_id");

            Property(t => t.Descricao)
                .IsRequired()
                .HasColumnName("descricao");

            Property(t => t.Privado)
                .IsRequired()
                .HasColumnName("privado");
        }
    }
}