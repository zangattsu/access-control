using CinSaude.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccessControl.Infra.CrossCutting.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(
            IOptions<JwtOptions> options,
            IConfiguration configuration)
        {
            new ConfigureFromConfigurationOptions<JwtOptions>(configuration.GetSection("JwtTokenOptions"))
                .Configure(options.Value);

            _options = options.Value;
        }

        public string Generate(string loginUsuario)
        {
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, loginUsuario),
                new(JwtRegisteredClaimNames.Name, loginUsuario)
            };

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                null);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}