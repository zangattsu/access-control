using CinSaude.Domain.Entities;

namespace CinSaude.Data.Repositories.Interface
{
    public interface IPacienteRepository : IGenericRepository<Paciente>
    {
        Paciente GetByEMail(string eMail);

        ICollection<Paciente> GetByConvenio(int convenioId);
    }
}