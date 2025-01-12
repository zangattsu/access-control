using AccessControl.Domain.Entities;

namespace AccessControl.Infra.CrossCutting.Interfaces.Repository
{
    public interface ISubdominioRepository : IRepositoryBase<Subdominio>
    {
        List<Subdominio> ObterSubdominios(int idDominio);
    }
}