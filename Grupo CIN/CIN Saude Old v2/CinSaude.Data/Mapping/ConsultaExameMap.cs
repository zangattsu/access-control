using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class ConsultaExameMap : EntityTypeConfiguration<ConsultaExame>
    {
        public ConsultaExameMap()
        {
            ToTable("consulta_exame");

            HasKey(t => new { t.ConsultaId, t.ExameId });

            Property(t => t.ConsultaId)
                .HasColumnName("id_consulta");

            Property(t => t.ExameId)
                .HasColumnName("id_exame");

            Property(t => t.UrlArquivo)
                .HasColumnName("url_arquivo");

            HasRequired(t => t.ConsultaMedica)
                    .WithMany(t => (ICollection<ConsultaExame>)t.Exames)
                    .HasForeignKey(d => d.ConsultaId).WillCascadeOnDelete(false);

            //HasRequired(t => t.Exames)
            //        .WithMany(t => t.Exame)
            //        .HasForeignKey(d => d.ExameId).WillCascadeOnDelete(false);
        }
    }
}