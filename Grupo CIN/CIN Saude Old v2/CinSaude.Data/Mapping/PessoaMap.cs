using CinSaude.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CinSaude.Data.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa");
            HasKey(t => t.PessoaId);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(256);
            Property(p => p.Status);
            Property(p => p.EMail);
        }
    }

    public class PessoaFisicaMap : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            ToTable("PessoaFisica");
            HasKey(t => t.PessoaFisicaId);

            Ignore(p => p.Nome);
            Ignore(p => p.Status);

            Property(t => t.PessoaId);
            Property(p => p.Nascimento);

            Property(t => t.Cpf)
                .IsRequired()
                .HasMaxLength(11);
            Property(t => t.Rg)
                .IsRequired()
                .HasMaxLength(12);
        }
    }

    public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            ToTable("PessoaJuridica");
            HasKey(t => t.PessoaJuridicaId);

            Ignore(p => p.Nome);
            Ignore(p => p.Status);

            Property(t => t.PessoaId);
            Property(t => t.Cnpj)
                .IsRequired()
                .HasMaxLength(14);
            Property(t => t.NomeFantasia)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}