namespace CinSaude.Domain.Entities
{
    public class EmpresaImagens
    {
        public int ImagensId { get; set; }
        public int EmpresaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Visible { get; set; }

        public virtual required Empresa Empresa { get; set; }
        public virtual required Imagens Imagem { get; set; }

    }
}