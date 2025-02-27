using CinSaude.Data.Repositories.Interface;
using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        internal new DbSet<Paciente> DbSet;

        public PacienteRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Paciente>();
        }

        public Paciente GetByEMail(string eMail)
        {
            Paciente paciente;

            if (!string.IsNullOrEmpty(eMail))
            {
                paciente = DbSet.FirstOrDefault(i => i.EMail == eMail);
            }
            else
            {
                paciente = new Paciente();
            }

            return paciente;
        }

        public ICollection<Paciente> GetByConvenio(int convenioId)
        {
            ICollection<Paciente> pacientes;

            if (convenioId > 0)
            {
                pacientes = DbSet.Where(i => i.ConvenioId == convenioId).ToList();
            }
            else
            {
                pacientes = new List<Paciente>();
            }

            return pacientes;
        }
    }
}