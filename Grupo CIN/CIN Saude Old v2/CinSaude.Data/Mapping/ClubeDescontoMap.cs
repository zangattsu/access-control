using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ClubeDescontoMap : EntityTypeConfiguration<ClubeDesconto>
    {
        public ClubeDescontoMap()
        {
            ToTable("clube_descontos");

            HasKey(t => t.DescontoId);

            Property(t => t.DescontoId)
                .IsRequired()
                .HasColumnName("desconto_id");

            Property(t => t.Empresa)
                .HasColumnName("empresa");
        }
    }
}