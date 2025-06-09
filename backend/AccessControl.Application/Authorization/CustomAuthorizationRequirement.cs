// Authorization/CustomAuthorizationRequirement.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

public class CustomAuthorizationRequirement : IAuthorizationRequirement
{
    // Propriedades personalizadas para o requisito
    public string RequiredPermission { get; }

    public CustomAuthorizationRequirement(string requiredPermission = null)
    {
        RequiredPermission = requiredPermission;
    }
}

public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
{
    private readonly ILogger<CustomAuthorizationHandler> _logger;

    public CustomAuthorizationHandler(ILogger<CustomAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        CustomAuthorizationRequirement requirement)
    {
        // Lógica personalizada de autorização

        // Exemplo: verificar uma claim específica
        if (!string.IsNullOrEmpty(requirement.RequiredPermission))
        {
            var permissionClaim = context.User.Claims.FirstOrDefault(
                c => c.Type == "permissions" && c.Value == requirement.RequiredPermission);

            if (permissionClaim != null)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }

        // Exemplo: verificar uma combinação de claims
        var userIdClaim = context.User.FindFirst("sub")?.Value;
        var tenantIdClaim = context.User.FindFirst("tenant_id")?.Value;

        if (!string.IsNullOrEmpty(userIdClaim) && !string.IsNullOrEmpty(tenantIdClaim))
        {
            // Lógica de negócio para verificar se o usuário tem acesso ao tenant
            // Pode ser uma chamada a um serviço ou banco de dados

            // Se a verificação for bem-sucedida:
            context.Succeed(requirement);
        }
        else
        {
            _logger.LogWarning("Autorização falhou para usuário {UserId}: faltam claims necessárias",
                userIdClaim ?? "desconhecido");
        }

        return Task.CompletedTask;
    }
}