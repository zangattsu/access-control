using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            HasKey(t => t.UsuarioId);

            Property(t => t.AtividadeFisica);
            Property(p => p.BebidasAlcoolicas);
            Property(p => p.DoadorOrgaos);
            Property(p => p.Fumante);
            Property(p => p.RecebeuTransfusao10Anos);
            Property(p => p.TipoSanguineo);
        }
    }
}