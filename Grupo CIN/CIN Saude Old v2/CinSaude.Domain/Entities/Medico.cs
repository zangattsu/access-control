using System.ComponentModel.DataAnnotations;

namespace CinSaude.Domain.Entities
{
    public class Medico
    {
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Médico.")]
        public string Nome { get; set; }

        public string Crm { get; set; }
        public string EMail { get; set; }

        //public int EspecialidadeId { get; set; }
        public string TelefoneCelular { get; set; }

        public string TelefoneFixo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int Status { get; set; }

        public int PacienteId { get; set; }

        public int? TipoId { get; set; }

        public int? EstadoId { get; set; }

        public DateTime? DataCadastro { get; set; }
        public int ConvenioId { get; set; }

        public Paciente Paciente { get; set; }
        public virtual Tipo Tipo { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual ICollection<ConsultaMedica> ConsultasMedicas { get; set; }
        public virtual ICollection<ResultadoExame> ResultadosDeExames { get; set; }
    }
}