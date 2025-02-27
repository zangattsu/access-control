namespace CinSaude.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string TipoSanguineo { get; set; }
        public bool DoadorOrgaos { get; set; }
        public bool RecebeuTransfusao10Anos { get; set; }
        public bool AtividadeFisica { get; set; }
        public bool BebidasAlcoolicas { get; set; }
        public bool Fumante { get; set; }

        public int PessoaFisicaId { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}