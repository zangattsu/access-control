using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ResultadoExameMap : EntityTypeConfiguration<ResultadoExame>
    {
        public ResultadoExameMap()
        {
            ToTable("resultado_exame");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .IsRequired()
                .HasColumnName("id");

            Property(t => t.PacienteId)
                .IsRequired()
                .HasColumnName("id_paciente");

            Property(t => t.MedicoId)
                .IsRequired()
                .HasColumnName("id_medico");

            Property(t => t.ExameId)
                .IsRequired()
                .HasColumnName("id_exame");

            Property(t => t.Data)
                .IsRequired()
                .HasColumnName("data");

            Property(t => t.Observacao)
                .HasColumnName("observacao");

            Property(t => t.UrlArquivo)
                .HasColumnName("url_arquivo");

            HasRequired(resultadoExame => resultadoExame.Paciente)
                    .WithMany(paciente => paciente.ResultadosDeExames)
                    .HasForeignKey(d => d.PacienteId).WillCascadeOnDelete(false);

            HasRequired(resultadoExame => resultadoExame.Medico)
                    .WithMany(medico => medico.ResultadosDeExames)
                    .HasForeignKey(d => d.MedicoId).WillCascadeOnDelete(false);

            HasRequired(resultadoExame => resultadoExame.Exame)
                    .WithMany(exame => exame.ResultadosDeExames)
                    .HasForeignKey(d => d.ExameId).WillCascadeOnDelete(false);
        }
    }
}