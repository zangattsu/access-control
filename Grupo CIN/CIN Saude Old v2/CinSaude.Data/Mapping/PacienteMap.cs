using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            ToTable("pacientes");
            HasKey(t => t.PacienteId);

            Property(t => t.PacienteId)
                .IsRequired()
                .HasColumnName("paciente_id");

            Property(t => t.DataCadastro)
                .HasColumnName("data_cadastro");

            Property(t => t.AtividadeFisica)
                .HasColumnName("atividade_fisica");

            Property(t => t.BebidasAlcoolicas)
                .HasColumnName("bebidas_alcoolicas");

            Property(t => t.Cidade)
                .HasColumnName("cidade");

            Property(t => t.Cpf)
                .HasColumnName("cpf");

            Property(t => t.DataNascimento)
                .HasColumnName("nascimento");

            Property(t => t.DoadorOrgaos)
                .HasColumnName("doador_orgaos");

            Property(t => t.EMail)
                .HasColumnName("email");

            Property(t => t.EstadoId)
                .HasColumnName("estado_id");

            Property(t => t.Fumante)
                .HasColumnName("fumante");

            Property(t => t.Genero)
                .HasColumnName("genero");

            Property(t => t.Nome)
                .IsRequired()
                .HasColumnName("nome");

            Property(t => t.RecebeuTransfusao10Anos)
                .HasColumnName("transfusao_10_anos");

            Property(t => t.Status)
                .HasColumnName("status");

            Property(t => t.TipoSanguineo)
                .HasColumnName("tipo_sanguineo");

            Property(t => t.ConvenioId)
               .HasColumnName("convenio_id");

            Property(t => t.Outro_Convenio)
                .HasColumnName("outro_convenio");

            Property(t => t.Qt_Dependentes)
                .HasColumnName("qt_dependentes");

            Property(t => t.DescontoId)
               .HasColumnName("desconto_id");

            HasRequired(t => t.Convenio)
                    .WithMany(t => t.Pacientes)
                    .HasForeignKey(d => d.ConvenioId).WillCascadeOnDelete(false);

            HasRequired(t => t.Estado)
                    .WithMany(t => t.Pacientes)
                    .HasForeignKey(d => d.EstadoId).WillCascadeOnDelete(false);

            HasRequired(t => t.ClubeDesconto)
                    .WithMany(t => t.Pacientes)
                    .HasForeignKey(d => d.DescontoId).WillCascadeOnDelete(false);
        }
    }
}