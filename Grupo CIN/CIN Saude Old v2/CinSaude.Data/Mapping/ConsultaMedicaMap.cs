using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ConsultaMedicaMap : EntityTypeConfiguration<ConsultaMedica>
    {
        public ConsultaMedicaMap()
        {
            ToTable("consulta_medica");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .IsRequired()
                .HasColumnName("consulta_id");

            Property(t => t.PacienteId)
                .IsRequired()
                .HasColumnName("paciente_id");

            Property(t => t.Data)
                .IsRequired()
                .HasColumnName("data");

            Property(t => t.MedicoId)
                .IsOptional()
                .HasColumnName("medico_id");

            Property(t => t.Observacao)
                .HasColumnName("observacao");

            Property(t => t.DependenteId)
                .IsOptional()
                .HasColumnName("dependente_id");

            Property(t => t.UrlArquivo)
                .HasColumnName("url_arquivo");

            //HasRequired(come => come.Paciente)
            //        .WithMany(paciente => paciente.ConsultasMedicas)
            //        .HasForeignKey(come => come.PacienteId).WillCascadeOnDelete(false);

            //HasOptional(come => come.Medico)
            //        .WithMany(medi => medi.ConsultasMedicas);
            ////.HasForeignKey(come => come.MedicoId).WillCascadeOnDelete(false);

            //HasOptional(come => come.Dependente)
            //        .WithMany(depe => depe.ConsultasMedicas);
            //.HasForeignKey(come => come.DependenteId).WillCascadeOnDelete(false);
        }
    }
}