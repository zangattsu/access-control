namespace CinSaude.Domain.Entities
{
    public class Pessoa
    {
        public virtual int PessoaId { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public string EMail { get; set; }

        public virtual ICollection<PessoaFisica> PessoasFisicas { get; set; }
        public virtual ICollection<PessoaJuridica> PessoasJuridicas { get; set; }
    }

    public class PessoaFisica
    {
        public int PessoaFisicaId { get; set; }
        public int PessoaId { get; set; }
        public DateTime Nascimento { get; set; }

        public string Nome
        {
            get { return Pessoa.Nome; }
            set { Pessoa.Nome = value; }
        }

        public bool Status
        {
            get { return Pessoa.Status; }
            set { Pessoa.Status = value; }
        }

        public string EMail
        {
            get { return Pessoa.EMail; }
            set { Pessoa.EMail = value; }
        }

        public string Cpf { get; set; }
        public string Rg { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Usuario Usuario { get; set; }

        public PessoaFisica()
        {
            Pessoa = new Pessoa();
        }

        public Pessoa GetPessoa()
        {
            return Pessoa;
        }
    }

    public sealed class PessoaJuridica
    {
        public int PessoaJuridicaId { get; set; }
        public int PessoaId { get; set; }

        public string Nome
        {
            get { return Pessoa.Nome; }
            set { Pessoa.Nome = value; }
        }

        public bool Status
        {
            get { return Pessoa.Status; }
            set { Pessoa.Status = value; }
        }

        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }

        public Pessoa Pessoa { get; set; }
        public Empresa Empresa { get; set; }

        public PessoaJuridica()
        {
            Pessoa = new Pessoa();
        }
    }

    public class PessoaEndereco
    {
        public int PessoaId { get; set; }
        public int EnderecoId { get; set; }
        public int TipoEnderecoId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
    }
}