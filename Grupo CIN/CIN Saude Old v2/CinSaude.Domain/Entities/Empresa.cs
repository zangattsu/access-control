namespace CinSaude.Domain.Entities
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public bool Status { get; set; }

        public int PessoaJuridicaId { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }

        public virtual IList<EmpresaImagens> Imagens { get; set; }
    }
}