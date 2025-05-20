namespace AccessControl.Infra.CrossCutting.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; init; } = "https://dev-21512408.okta.com/oauth2/default";
        public string Audience { get; init; } = "api://default";
        public string? SecretKey { get; init; }
    }
}