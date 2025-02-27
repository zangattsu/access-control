using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ParentescoMap : EntityTypeConfiguration<Parentesco>
    {
        public ParentescoMap()
        {
            ToTable("parentesco");

            HasKey(t => t.ParentescoId);

            Property(t => t.ParentescoId)
                .IsRequired()
                .HasColumnName("parentesco_id");

            Property(t => t.Descricao)
                .HasColumnName("descricao");
        }
    }
}