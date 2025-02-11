using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class DoencaMap : EntityTypeConfiguration<Doenca>
    {
        public DoencaMap()
        {
            ToTable("doenca_pre");

            HasKey(t => t.DoencaId);

            Property(t => t.DoencaId)
                .IsRequired()
                .HasColumnName("doenca_id");

            Property(t => t.Descricao)
                .HasColumnName("descricao");

            Property(t => t.Data_Diagnostico)
                .HasColumnName("data_diagnostico");

            Property(t => t.PacienteId)
                .HasColumnName("paciente_id");

            HasRequired(doenca => doenca.Paciente)
                    .WithMany(t => t.Doencas)
                    .HasForeignKey(d => d.PacienteId).WillCascadeOnDelete(false);
        }
    }
}