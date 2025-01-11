using CinSaude.Domain.Interfaces.Repository;
using CinSaude.Domain.Models;

namespace AccessControl.Domain.Entities
{
    public class Dominio : Entity<Dominio>
    {
        private readonly ISubdominioRepository _subdominioRepository;
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public List<Subdominio> Subdominos { get; set; }

        public Dominio(
            string codigo,
            string descricao,
            ISubdominioRepository subdominioRepository) : this(codigo, descricao)
        {
            _subdominioRepository = subdominioRepository;
        }

        private Dominio(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;

            if (Id > 0)
            {
                Subdominos = ObterSubdominios();
            }
        }

        private List<Subdominio> ObterSubdominios()
        {
            return _subdominioRepository.ObterSubdominios(Id);
        }
    }
}