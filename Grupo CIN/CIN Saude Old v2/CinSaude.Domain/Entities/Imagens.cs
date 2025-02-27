namespace CinSaude.Domain.Entities
{
    public class Imagens
    {
        public int ImagensId { get; set; }
        public int ImagensDominioId { get; set; }
        public string ImagemPath { get; set; }

        public virtual ImagensDominio ImagensDominio { get; set; }
    }

    public class ImagensDominio
    {
        public int ImagensDominioId { get; set; }
        public string Tipo { get; set; }
        public string SubTipo { get; set; }
    }
}