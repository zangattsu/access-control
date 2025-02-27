using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class MedicamentoMap : EntityTypeConfiguration<Medicamento>
    {
        public MedicamentoMap()
        {
            ToTable("medicamentos");

            HasKey(t => t.MedicamentoId);

            Property(t => t.MedicamentoId)
                .IsRequired()
                .HasColumnName("medicamento_id");

            Property(t => t.Nome)
                .HasColumnName("nome");

            Property(t => t.Data_Inicio)
                .HasColumnName("data_inicio");

            Property(t => t.Em_Uso)
                .HasColumnName("em_uso");

            Property(t => t.Dosagem)
                .HasColumnName("dosagem");

            Property(t => t.Prazo)
                .HasColumnName("prazo");

            Property(t => t.Uso_Continuo)
                .HasColumnName("uso_continuo");

            Property(t => t.PacienteId)
                .HasColumnName("paciente_id");

            Property(t => t.Publico)
                .HasColumnName("publico");

            HasRequired(medicamento => medicamento.Paciente)
                    .WithMany(t => t.Medicamentos)
                    .HasForeignKey(d => d.PacienteId).WillCascadeOnDelete(false);
        }
    }
}