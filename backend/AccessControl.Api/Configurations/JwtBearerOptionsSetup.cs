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

            _jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions.Value));
        }

        public void Configure(JwtBearerOptions options)
        {
            if (string.IsNullOrEmpty(_jwtOptions.SecretKey))
            {
                throw new ArgumentNullException(nameof(_jwtOptions.SecretKey), "SecretKey cannot be null or empty.");
            }

            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))
            };
        }
    }
}