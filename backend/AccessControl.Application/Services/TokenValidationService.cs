using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
// Services/TokenValidationService.cs
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace AccessControl.Application.Services
{
    public interface ITokenValidationService
    {
        Task<bool> ValidateTokenAdditionalChecks(SecurityToken token);
        Task<ClaimsPrincipal> ValidateTokenManually(string token);
    }

    public class TokenValidationService : ITokenValidationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TokenValidationService> _logger;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public TokenValidationService(
            IHttpClientFactory httpClientFactory,
            ILogger<TokenValidationService> logger,
            IMemoryCache cache,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<bool> ValidateTokenAdditionalChecks(SecurityToken token)
        {
            if (token is JwtSecurityToken jwtToken)
            {
                // Verifica se o token está na lista de revogados
                if (await IsTokenRevoked(jwtToken.RawData))
                {
                    _logger.LogWarning("Token revogado tentando acessar a API: {TokenId}", jwtToken.Id);
                    return false;
                }

                // Verificações adicionais específicas do seu domínio
                // Por exemplo, verificar se o usuário ainda está ativo no seu sistema
                var sub = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
                if (!string.IsNullOrEmpty(sub) && !await IsUserActive(sub))
                {
                    _logger.LogWarning("Usuário inativo tentando acessar a API: {UserId}", sub);
                    return false;
                }

                return true;
            }

            return false;
        }

        public async Task<ClaimsPrincipal> ValidateTokenManually(string token)
        {
            try
            {
                // Obtém as chaves de assinatura do Okta
                var keys = await GetSigningKeys();

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Okta:Authority"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Okta:Audience"],
                    //ValidateLifetime = true,
                    //IssuerSigningKeys = keys,
                    //ClockSkew = TimeSpan.FromMinutes(2)
                };

                var handler = new JwtSecurityTokenHandler();
                var principal = handler.ValidateToken(token, validationParameters, out var validatedToken);

                return principal;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao validar token manualmente");
                throw;
            }
        }

        private async Task<bool> IsTokenRevoked(string token)
        {
            // Implementação para verificar se o token está na lista de revogados
            // Pode usar Redis, banco de dados ou chamada à API do Okta

            // Exemplo simplificado usando cache
            string cacheKey = $"revoked_token_{ComputeHash(token)}";

            if (_cache.TryGetValue(cacheKey, out bool isRevoked))
            {
                return isRevoked;
            }

            // Verificação real (chamada ao Okta ou sua base de dados)
            using var client = _httpClientFactory.CreateClient("OktaInternal");
            var response = await client.GetAsync($"api/v1/tokens/revocation?token={Uri.EscapeDataString(token)}");

            isRevoked = response.IsSuccessStatusCode;

            // Armazena em cache por um período
            _cache.Set(cacheKey, isRevoked, TimeSpan.FromMinutes(5));

            return isRevoked;
        }

        private async Task<bool> IsUserActive(string userId)
        {
            // Implementação para verificar se o usuário está ativo
            // Pode ser uma chamada ao Okta ou ao seu banco de dados

            // Exemplo simplificado
            using var client = _httpClientFactory.CreateClient("OktaInternal");
            var response = await client.GetAsync($"api/v1/users/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<JsonDocument>();
                var status = content?.RootElement.GetProperty("status").GetString();

                return status == "ACTIVE";
            }

            return false;
        }

        private async Task<IEnumerable<SecurityKey>> GetSigningKeys()
        {
            // Obtém as chaves de assinatura do Okta
            // Usa cache para evitar chamadas frequentes

            string cacheKey = "okta_signing_keys";

            if (_cache.TryGetValue(cacheKey, out IEnumerable<SecurityKey> keys))
            {
                return keys;
            }

            // Obtém as chaves do endpoint JWKS do Okta
            using var client = _httpClientFactory.CreateClient();
            var jwksUri = $"{_configuration["Okta:Authority"]}/.well-known/jwks.json";
            var response = await client.GetAsync(jwksUri);

            response.EnsureSuccessStatusCode();

            var jwks = await response.Content.ReadFromJsonAsync<JsonWebKeySet>();
            keys = jwks.Keys.Select(k => k as SecurityKey);

            // Armazena em cache por um período
            _cache.Set(cacheKey, keys, TimeSpan.FromHours(24));

            return keys;
        }

        private string ComputeHash(string input)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
