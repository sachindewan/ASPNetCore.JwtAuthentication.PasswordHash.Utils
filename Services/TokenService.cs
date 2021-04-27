using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AspNetCore.JwtAuthentication.PasswordHasing.Plugin
{
    public class TokenService : ITokenService
    {
        private const string defaultSigningKey = "123456789";
        public string GenerateAccessToken(IEnumerable<Claim> claims=null, string validIssuer=null, string validAudience=null, string issuerSigningKey=null,string expireIn=null)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((issuerSigningKey is  null)? defaultSigningKey: issuerSigningKey));

                var jwtToken = new JwtSecurityToken(issuer: validIssuer,
                    audience: validAudience,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(int.Parse(expireIn)),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
            catch
            {
                throw;
            }
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token,bool validateAudience,bool validateIssuer,bool validateLifeTime,  string issuerSigningKey=null)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = validateAudience, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = validateIssuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((issuerSigningKey is null) ? defaultSigningKey : issuerSigningKey)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
