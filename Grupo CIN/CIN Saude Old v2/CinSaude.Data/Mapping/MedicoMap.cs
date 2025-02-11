using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class MedicoMap : EntityTypeConfiguration<Medico>
    {
        public MedicoMap()
        {
            ToTable("medicos");
            HasKey(t => t.MedicoId);

            Property(t => t.MedicoId)
                .IsRequired()
                .HasColumnName("medico_id");

            Property(t => t.Nome)
                .HasColumnName("nome");

            Property(t => t.Cidade)
                .HasColumnName("cidade");

            Property(t => t.Bairro)
                .HasColumnName("bairro");

            Property(t => t.Complemento)
                .HasColumnName("complemento");

            Property(t => t.Crm)
                .HasColumnName("crm");

            Property(t => t.EMail)
                .HasColumnName("email");

            Property(t => t.Logradouro)
                .HasColumnName("logradouro");

            Property(t => t.Numero)
                .HasColumnName("numero");

            Property(t => t.TelefoneCelular)
                .HasColumnName("telefone_celular");

            Property(t => t.TelefoneFixo)
                .HasColumnName("telefone_fixo");

            Property(t => t.Cep)
                .HasColumnName("cep");

            Property(t => t.PacienteId)
                .HasColumnName("paciente_id");

            Property(t => t.TipoId)
                .HasColumnName("tipo_id");

            Property(t => t.ConvenioId)
                .HasColumnName("convenio_id");

            Property(t => t.DataCadastro)
                .HasColumnName("data_cadastro");

            Property(t => t.Status)
                .HasColumnName("status");

            Property(t => t.EstadoId)
                .HasColumnName("estado_id");

            HasRequired(medico => medico.Tipo)
                    .WithMany(tipo => tipo.Medicos)
                    .HasForeignKey(d => d.TipoId).WillCascadeOnDelete(false);

            HasRequired(medico => medico.Estado)
                    .WithMany(estado => estado.Medicos)
                    .HasForeignKey(d => d.EstadoId).WillCascadeOnDelete(false);
        }
    }
}