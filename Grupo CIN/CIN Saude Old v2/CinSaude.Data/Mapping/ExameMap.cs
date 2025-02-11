using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ExameMap : EntityTypeConfiguration<Exame>
    {
        public ExameMap()
        {
            ToTable("exames");

            HasKey(t => t.ExameId);

            Property(t => t.ExameId)
                .IsRequired()
                .HasColumnName("exame_id");

            Property(t => t.Descricao)
                .HasColumnName("descricao");

            Property(t => t.CodigoConvenio)
                .HasColumnName("codigo_convenio");

            Property(t => t.PacienteId)
                .HasColumnName("paciente_id");

            Property(t => t.UrlArquivo)
                .HasColumnName("urlImagem");

            HasRequired(exame => exame.Paciente)
                    .WithMany(t => t.Exames)
                    .HasForeignKey(d => d.PacienteId).WillCascadeOnDelete(false);
        }
    }
}