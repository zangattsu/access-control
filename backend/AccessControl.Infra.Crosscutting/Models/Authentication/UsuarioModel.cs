namespace AccessControl.Infra.CrossCutting.Models.Authentication
{
    public class UsuarioModel
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public string SistemaOrigem { get; set; }

        //public UsuarioModel(string nomeUsuario, string sitemaOrigem)
        //{
        //    NomeUsuario = nomeUsuario;
        //    SistemaOrigem = sitemaOrigem;
        //}
    }
}