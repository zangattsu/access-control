using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class EspecialidadeMap : EntityTypeConfiguration<Especialidade>
    {
        public EspecialidadeMap()
        {
            ToTable("especialidades");
            HasKey(t => t.EspecialidadeId);

            Property(t => t.EspecialidadeId)
                .IsRequired()
                .HasColumnName("especialidade_id");

            Property(t => t.Descricao)
                .HasColumnName("descricao");

            Property(t => t.Nome)
                .HasColumnName("nome");
        }
    }
}