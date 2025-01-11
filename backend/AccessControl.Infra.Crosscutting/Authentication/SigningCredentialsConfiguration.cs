using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AccessControl.Infra.CrossCutting.Authentication
{
    public class SigningCredentialsConfiguration
    {
        private JwtOptions _jwtOptions;

        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey.ToString())),
                SecurityAlgorithms.HmacSha256Signature);
        }
    }
}