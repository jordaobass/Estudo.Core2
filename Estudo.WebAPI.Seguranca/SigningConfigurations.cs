using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Alura.WebAPI.Seguranca
{
    public class SigningConfigurations
    {
        private readonly string secret = "mysupersecret_secretkey!123";
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            var keyByteArray = Encoding.ASCII.GetBytes(secret);
            Key = new SymmetricSecurityKey(keyByteArray);
            SigningCredentials = new SigningCredentials(
                Key,
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
