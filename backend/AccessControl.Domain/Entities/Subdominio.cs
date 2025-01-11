using AccessControl.Domain.Entities.Authentication;
using CinSaude.Domain.Interfaces.Repository;
using CinSaude.Domain.Models;
using System.Globalization;

namespace AccessControl.Domain.Entities
{
    public class Subdominio : Entity<Subdominio>
    {
        private readonly IDominioRepository _dominioRepository;

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public int IdDominio { get; set; }

        public Dominio Dominio { get; set; }

        public List<Usuario> Usuarios { get; set; }


        public Subdominio(
            string codigo,
            string descricao,
            int idDominio,
            IDominioRepository domainRepository) : this(codigo, descricao, idDominio)
        {
            _dominioRepository = domainRepository;
        }

        private Subdominio(string codigo, string descricao, int idDominio)
        {
            Codigo = codigo;
            Descricao = descricao;
            IdDominio = idDominio;

            //Dominio = ObterDominio();
        }

        private Dominio ObterDominio()
        {
            return _dominioRepository.Get(IdDominio);
        }
    }
}