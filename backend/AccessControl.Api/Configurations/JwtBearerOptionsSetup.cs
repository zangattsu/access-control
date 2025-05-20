using AccessControl.Infra.CrossCutting.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AccessControl.Api.Configurations
{
    public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions;

        public JwtBearerOptionsSetup(
            IOptions<JwtOptions> jwtOptions,
            IConfiguration configuration)
        {
            new ConfigureFromConfigurationOptions<JwtOptions>(configuration.GetSection("JwtTokenOptions"))
                .Configure(jwtOptions.Value);

            _jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions.Value).ToString());
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtOptions.Audience,
                ValidateLifetime = true,
            };

            // Defina o endereço do operador de tokens do Okta (issuer)
            options.Authority = _jwtOptions.Issuer;

            // Defina o audience (recursos da API) conforme configurado no Okta
            options.Audience = _jwtOptions.Audience;
        }
    }
}