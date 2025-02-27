using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ApplicationMenuMap : EntityTypeConfiguration<ApplicationMenu>
    {
        public ApplicationMenuMap()
        {
            HasKey(t => t.ApplicationMenuId);

            Property(t => t.Route).IsRequired().HasMaxLength(150);
            Property(p => p.Description);
            Property(p => p.Module);
            Property(p => p.RequiresAuthenication).IsRequired();
        }
    }
}