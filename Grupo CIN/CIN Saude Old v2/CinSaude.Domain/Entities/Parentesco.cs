namespace CinSaude.Domain.Entities
{
    public class Parentesco
    {
        public int ParentescoId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Dependente> Dependentes { get; set; }
    }
}