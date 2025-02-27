namespace CinSaude.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Municipio { get; set; }
    }

    public class TipoEndereco
    {
        public int TipoenderecoId { get; set; }
        public string Descricao { get; set; }
    }
}