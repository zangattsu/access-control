using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AccessControl.Infra.CrossCutting.Authentication
{
    public class SigningCredentialsConfiguration
    {
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration(JwtOptions jwtOptions)
        {
            _ = jwtOptions.SecretKey ?? 
                throw new ArgumentNullException(nameof(jwtOptions.SecretKey).ToString().ToString(), "SecretKey cannot be null or empty.");

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey.ToString())),
                SecurityAlgorithms.HmacSha256Signature);
        }
    }
}