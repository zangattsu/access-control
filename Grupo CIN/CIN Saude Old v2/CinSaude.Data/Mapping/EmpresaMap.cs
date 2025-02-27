using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("Empresa");
            HasKey(t => t.EmpresaId);

            Property(t => t.EmpresaId)
                .IsRequired();

            Property(t => t.PessoaJuridicaId)
                .IsRequired();

            Property(t => t.Status)
                .IsRequired();
        }
    }
}