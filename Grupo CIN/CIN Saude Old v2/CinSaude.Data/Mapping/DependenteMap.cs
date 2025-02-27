using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class DependenteMap : EntityTypeConfiguration<Dependente>
    {
        public DependenteMap()
        {
            ToTable("dependentes");

            HasKey(t => t.DependenteId);

            Property(t => t.DependenteId)
                .IsRequired()
                .HasColumnName("dependente_id");

            Property(t => t.Nome)
                .HasColumnName("nome");

            Property(t => t.Genero)
                .HasColumnName("genero");

            Property(t => t.Nascimento)
                .HasColumnName("nascimento");

            Property(t => t.PacienteId)
                .HasColumnName("paciente_id");

            Property(t => t.ParentescoId)
                .HasColumnName("parentesco_id");

            HasRequired(dependente => dependente.Paciente)
                    .WithMany(t => t.Dependentes)
                    .HasForeignKey(d => d.PacienteId).WillCascadeOnDelete(false);

            HasRequired(dependente => dependente.Parentesco)
                    .WithMany(parentesco => parentesco.Dependentes)
                    .HasForeignKey(d => d.ParentescoId).WillCascadeOnDelete(false);
        }
    }
}