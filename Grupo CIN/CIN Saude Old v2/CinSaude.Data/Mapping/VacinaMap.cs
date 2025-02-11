using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class VacinaMap : EntityTypeConfiguration<Vacina>
    {
        public VacinaMap()
        {
            ToTable("vacinas");

            HasKey(t => t.VacinaId);

            Property(t => t.VacinaId)
                .IsRequired()
                .HasColumnName("vacina_id");

            Property(t => t.PacienteId)
                .IsRequired()
                .HasColumnName("paciente_id");

            Property(t => t.DependenteId)
                .IsRequired()
                .HasColumnName("dependente_id");

            Property(t => t.Data)
                .IsRequired()
                .HasColumnName("data");

            Property(t => t.Descricao)
                .HasColumnName("descricao");

            Property(t => t.Local)
                .HasColumnName("local");

            Property(t => t.Observacao)
                .HasColumnName("observacao");

            HasRequired(dependente => dependente.Dependente)
                    .WithMany(consulta => consulta.Dependentes)
                    .HasForeignKey(d => d.DependenteId).WillCascadeOnDelete(false);
        }
    }
}