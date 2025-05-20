using AccessControl.Infra.CrossCutting.Authentication;
using AccessControl.Infra.CrossCutting.Models.Identity;
using AccessControl.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AccessControl.Api.Configurations
{
    public static class MvcSecurityConfiguration
    {
        public static void AddMvcSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var tokenConfigurations = new JwtOptions();

            new ConfigureFromConfigurationOptions<JwtOptions>(configuration.GetSection("JwtTokenOptions"))
                .Configure(tokenConfigurations);

            var signingConf = new SigningCredentialsConfiguration(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DefaultContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = false;
                bearerOptions.SaveToken = true;

                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingConf.SigningCredentials.Key,
                    ValidAudience = tokenConfigurations.Audience,
                    ValidIssuer = tokenConfigurations.Issuer,
                    RequireExpirationTime = true
                };
            });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }
    }
}