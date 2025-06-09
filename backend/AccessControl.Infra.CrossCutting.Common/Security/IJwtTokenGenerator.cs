namespace AccessControl.Infra.CrossCutting.Common.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(IUser user);
    }
}
