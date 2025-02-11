using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class EmpresaImagensMap : EntityTypeConfiguration<EmpresaImagens>
    {
        public EmpresaImagensMap()
        {
            ToTable("EmpresaImagens");
            HasKey(t => new { t.EmpresaId, t.ImagensId });

            Property(p => p.Visible).IsRequired();

            HasRequired(t => t.Empresa)
                .WithMany(t => t.Imagens)
                .HasForeignKey(d => d.EmpresaId).WillCascadeOnDelete(false);
        }
    }
}